using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NBDv2.Data;
using NBDv2.Models;
using NBDv2.ViewModel;

namespace NBDv2.Controllers
{
    [Authorize(Roles = "Admin, Worker")]
    public class ProductionPlan : Controller
    {
        private readonly NBDContext _context;

        public ProductionPlan(NBDContext context)
        {
            _context = context;
        }

        // GET: ProductionPlan
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.Projects.Include(p => p.Client).Include(p => p.Designer);
            return View(await nBDContext.ToListAsync());
        }

        // GET: ProductionPlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Designer)
                .Include(p => p.ProjectMaterials).ThenInclude(m => m.Inventory).ThenInclude(i => i.Material)
                .Include(p => p.ProjectEmployees).ThenInclude(m => m.Employee).ThenInclude(i => i.EmployeeType)
                .Include(p => p.ProjectEmployees).ThenInclude(m => m.Labours).ThenInclude(i => i.Task)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ConFirst");
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Desc,EstCost,BidDate,EstStartDate,EstFinishDate,CurrentPhase,StartDate,FinishDate,Cost,BidCustApproved,BidManagementApproved,ClientID,DesignerID")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ConFirst", project.ClientID);
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "FirstName", project.DesignerID);
            return View(project);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Designer)
                .Include(p => p.ProjectEmployees).ThenInclude(p => p.Employee).ThenInclude(p => p.EmployeeType)
                .Include(p => p.ProjectEmployees).ThenInclude(m => m.Labours).ThenInclude(i => i.Task)
                .Include(p => p.ProjectMaterials).ThenInclude(p => p.Inventory).ThenInclude(p => p.Material)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ID == id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ConFirst", project.ClientID);
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "FirstName", project.DesignerID);
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Desc,EstCost,BidDate,EstStartDate,EstFinishDate,CurrentPhase,StartDate,FinishDate,Cost,BidCustApproved,BidManagementApproved,ClientID,DesignerID")] Project project)
        {
            if (id != project.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ConFirst", project.ClientID);
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "FirstName", project.DesignerID);
            return View(project);
        }

        // GET: ProductionPlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Designer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: ProductionPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }

        public async Task<IActionResult> UpdateTeam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectToUpdate = await _context.Projects
                  .Include(d => d.ProjectEmployees).ThenInclude(d => d.Employee)
                  .AsNoTracking()
                  .SingleOrDefaultAsync(d => d.ID == id);

            PopulateAssignedEmployees(projectToUpdate);
            return View(projectToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTeam(int id, string[] selectedOptions)
        {
            var projectToUpdate = await _context.Projects
                .Include(d => d.ProjectEmployees).ThenInclude(d => d.Employee)
                .SingleOrDefaultAsync(d => d.ID == id);

            //Check that you got it or exit with a not found error
            if (projectToUpdate == null)
            {
                return NotFound();
            }

            //Update the Doctor's Specialties
            UpdateProjectEmployees(selectedOptions, projectToUpdate);

            //Try updating it with the values posted...
            if (await TryUpdateModelAsync<Project>(projectToUpdate))
            {

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(projectToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }

            }
            //Validaiton Error so give the user another chance.
            PopulateAssignedEmployees(projectToUpdate);
            return View(projectToUpdate);

        }

        private void PopulateAssignedEmployees(Project project)
        {
            var allEmployees = _context.Employees;
            var projEmployees = new HashSet<int>(project.ProjectEmployees.Select(b => b.EmployeeID));
            var selected = new List<OptionVM>();
            var available = new List<OptionVM>();
            foreach (var s in allEmployees)
            {
                if (projEmployees.Contains(s.ID))
                {
                    selected.Add(new OptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.FullName
                    });
                }
                else
                {
                    available.Add(new OptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.FullName
                    });
                }
            }
            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }

        private void UpdateProjectEmployees(string[] selectedOptions, Project projectToUpdate)
        {
            if (selectedOptions == null)
            {
                projectToUpdate.ProjectEmployees = new List<ProjectEmployee>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var projEmployees = new HashSet<int>(projectToUpdate.ProjectEmployees.Select(b => b.EmployeeID));
            foreach (var s in _context.Employees)
            {
                if (selectedOptionsHS.Contains(s.ID.ToString()))
                {
                    if (!projEmployees.Contains(s.ID))
                    {
                        projectToUpdate.ProjectEmployees.Add(new ProjectEmployee
                        {
                            EmployeeID = s.ID,
                            ProjectID = projectToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (projEmployees.Contains(s.ID))
                    {
                        ProjectEmployee employeeToRemove = projectToUpdate.ProjectEmployees.SingleOrDefault(d => d.EmployeeID == s.ID);
                        _context.Remove(employeeToRemove);
                    }
                }
            }
        }


        public async Task<IActionResult> UpdateMaterials(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectToUpdate = await _context.Projects
                  .Include(d => d.ProjectMaterials).ThenInclude(pm => pm.Inventory)
                  .AsNoTracking()
                  .SingleOrDefaultAsync(d => d.ID == id);

            PopulateAssignedMaterials(projectToUpdate);
            return View(projectToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMaterials(int id, string[] selectedMatOptions, string[] selectedMatQuantity)
        {
            var projectToUpdate = await _context.Projects
                .Include(d => d.ProjectEmployees).ThenInclude(d => d.Employee)
                .SingleOrDefaultAsync(d => d.ID == id);

            //Check that you got it or exit with a not found error
            if (projectToUpdate == null)
            {
                return NotFound();
            }

            //Update the Doctor's Specialties
            UpdateAssignedMaterials(selectedMatOptions, selectedMatQuantity, projectToUpdate);

            //Try updating it with the values posted...
            if (await TryUpdateModelAsync<Project>(projectToUpdate))
            {

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(projectToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }

            }
            //Validaiton Error so give the user another chance.
            PopulateAssignedMaterials(projectToUpdate);
            return View(projectToUpdate);

        }


        private void PopulateAssignedMaterials(Project project)
        {
            var plants = _context.Inventories.Include(i => i.Material).Where(i => i.Material.Type == "Plant");
            var pottery = _context.Inventories.Include(i => i.Material).Where(i => i.Material.Type == "Pottery");
            var material = _context.Inventories.Include(i => i.Material).Where(i => i.Material.Type == "Material");
            var pInventory = new HashSet<int>(project.ProjectMaterials.Select(b => b.InventoryID));
            var plantCheckBoxes = new List<OptionVM>();
            var potteryCheckBoxes = new List<OptionVM>();
            var matCheckBoxes = new List<OptionVM>();
            foreach (var plant in plants)
            {
                int Qty = 0;
                if (pInventory.Contains(plant.ID))
                {
                    var qty = project.ProjectMaterials.FirstOrDefault(p => p.InventoryID == plant.ID);
                    Qty = qty.MatEstQty;
                }

                plantCheckBoxes.Add(new OptionVM
                {
                    ID = plant.ID,
                    DisplayText = plant.Material.Desc,
                    Quantity = Qty,
                    Assigned = pInventory.Contains(plant.ID)
                });
            }
            foreach (var pot in pottery)
            {
                int Qty = 0;
                if (pInventory.Contains(pot.ID))
                {
                    var qty = project.ProjectMaterials.FirstOrDefault(p => p.InventoryID == pot.ID);
                    Qty = qty.MatEstQty;
                }

                potteryCheckBoxes.Add(new OptionVM
                {
                    ID = pot.ID,
                    DisplayText = pot.Material.Desc,
                    Quantity = Qty,
                    Assigned = pInventory.Contains(pot.ID)
                });
            }
            foreach (var mat in material)
            {
                int Qty = 0;
                if (pInventory.Contains(mat.ID))
                {
                    var qty = project.ProjectMaterials.FirstOrDefault(p => p.InventoryID == mat.ID);
                    Qty = qty.MatEstQty;
                }

                matCheckBoxes.Add(new OptionVM
                {
                    ID = mat.ID,
                    DisplayText = mat.Material.Desc,
                    Quantity = Qty,
                    Assigned = pInventory.Contains(mat.ID)
                });
            }
            ViewData["Plants"] = plantCheckBoxes;
            ViewData["Pottery"] = potteryCheckBoxes;
            ViewData["Materials"] = matCheckBoxes;
        }

        private void UpdateAssignedMaterials(string[] selectedMatOptions, string[] selectedMatQuantity, Project projectToUpdate)
        {
            if (selectedMatOptions == null)
            {
                projectToUpdate.LabourSummaries = new List<LabourSummary>();
                return;
            }

            int ctr = 0;

            var selectedMatsHS = new HashSet<string>(selectedMatOptions);
            var selectedMatQuantityHS = new HashSet<string>(selectedMatQuantity);
            var ProjectMaterialsHS = new HashSet<int>
                (projectToUpdate.ProjectMaterials.Select(c => c.InventoryID));

            foreach (var inventory in _context.Inventories)
            {
                if (selectedMatsHS.Contains(inventory.ID.ToString()))
                {
                    if (ProjectMaterialsHS.Contains(inventory.ID))
                    {
                        ProjectMaterials inventoryToRemove = projectToUpdate.ProjectMaterials.SingleOrDefault(c => c.InventoryID == inventory.ID);
                        _context.Remove(inventoryToRemove);
                        projectToUpdate.ProjectMaterials.Add(new ProjectMaterials { ProjectID = projectToUpdate.ID, InventoryID = inventory.ID, MatEstQty = int.Parse(selectedMatQuantity[ctr]) });
                    }
                    if (!ProjectMaterialsHS.Contains(inventory.ID))
                    {
                        projectToUpdate.ProjectMaterials.Add(new ProjectMaterials { ProjectID = projectToUpdate.ID, InventoryID = inventory.ID, MatEstQty = int.Parse(selectedMatQuantity[ctr]) });
                    }
                    ctr++;
                }
                else
                {
                    if (ProjectMaterialsHS.Contains(inventory.ID))
                    {
                        ProjectMaterials inventoryToRemove = projectToUpdate.ProjectMaterials.SingleOrDefault(c => c.InventoryID == inventory.ID);
                        _context.Remove(inventoryToRemove);
                    }
                }
            }
        }

        

        private void PopulateTeamDDL(Project project)
        {
            HashSet<Employee> employees = new HashSet<Employee>();
            foreach(ProjectEmployee p in project.ProjectEmployees)
            {
                employees.Add(p.Employee);
            }
            ViewData["Team"] = new SelectList(employees
                .OrderBy(d => d.FullName), "ID", "FullName");
        }







        public async Task<IActionResult> UpdateLabours(int? id, int? teamID)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectToUpdate = await _context.Projects
                  .Include(d => d.ProjectEmployees).ThenInclude(d => d.Employee)
                  .AsNoTracking()
                  .SingleOrDefaultAsync(d => d.ID == id);

            PopulateTeamDDL(projectToUpdate);
            PopulateAssignedLabours(teamID, projectToUpdate);
            return View(projectToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLabours(int id, string[] selectedMatOptions, string[] selectedMatQuantity)
        {
            var projectToUpdate = await _context.Projects
                .Include(d => d.ProjectEmployees).ThenInclude(d => d.Employee)
                .SingleOrDefaultAsync(d => d.ID == id);

            //Check that you got it or exit with a not found error
            if (projectToUpdate == null)
            {
                return NotFound();
            }

            //Update the Doctor's Specialties
            UpdateAssignedMaterials(selectedMatOptions, selectedMatQuantity, projectToUpdate);

            //Try updating it with the values posted...
            if (await TryUpdateModelAsync<Project>(projectToUpdate))
            {

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(projectToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }

            }
            //Validaiton Error so give the user another chance.
            PopulateAssignedMaterials(projectToUpdate);
            return View(projectToUpdate);

        }

        private void PopulateAssignedLabours(int? teamID, Project project)
        {
            var empLabours = _context.Labours.Where(l => l.TeamID == teamID);
            var labourControls = new List<OptionVM>();
            foreach (var labour in empLabours)
            {
                labourControls.Add(new OptionVM
                {
                    ID = labour.ID,
                    DisplayText = labour.Task.Desc,
                    Quantity = labour.Hours,
                    Date = labour.StartDate
                });
            }
            ViewData["Labours"] = labourControls;
        }

        private void UpdateMaterials(string[] selectedMatOptions, string[] selectedMatQuantity, Project projectToUpdate)
        {
            if (selectedMatOptions == null)
            {
                projectToUpdate.LabourSummaries = new List<LabourSummary>();
                return;
            }

            int ctr = 0;

            var selectedMatsHS = new HashSet<string>(selectedMatOptions);
            var selectedMatQuantityHS = new HashSet<string>(selectedMatQuantity);
            var ProjectMaterialsHS = new HashSet<int>
                (projectToUpdate.ProjectMaterials.Select(c => c.InventoryID));

            foreach (var inventory in _context.Inventories)
            {
                if (selectedMatsHS.Contains(inventory.ID.ToString()))
                {
                    if (ProjectMaterialsHS.Contains(inventory.ID))
                    {
                        ProjectMaterials inventoryToRemove = projectToUpdate.ProjectMaterials.SingleOrDefault(c => c.InventoryID == inventory.ID);
                        _context.Remove(inventoryToRemove);
                        projectToUpdate.ProjectMaterials.Add(new ProjectMaterials { ProjectID = projectToUpdate.ID, InventoryID = inventory.ID, MatEstQty = int.Parse(selectedMatQuantity[ctr]) });
                    }
                    if (!ProjectMaterialsHS.Contains(inventory.ID))
                    {
                        projectToUpdate.ProjectMaterials.Add(new ProjectMaterials { ProjectID = projectToUpdate.ID, InventoryID = inventory.ID, MatEstQty = int.Parse(selectedMatQuantity[ctr]) });
                    }
                    ctr++;
                }
                else
                {
                    if (ProjectMaterialsHS.Contains(inventory.ID))
                    {
                        ProjectMaterials inventoryToRemove = projectToUpdate.ProjectMaterials.SingleOrDefault(c => c.InventoryID == inventory.ID);
                        _context.Remove(inventoryToRemove);
                    }
                }
            }
        }
    }

}

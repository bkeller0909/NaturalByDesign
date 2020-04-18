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
    [Authorize(Roles = "Admin, Designer")]
    public class BidController : Controller
    {
        private readonly NBDContext _context;

        public BidController(NBDContext context)
        {
            _context = context;
        }

        // GET: Bid
        public async Task<IActionResult> Index()
        {
            var NBDContext = _context.Projects.Include(p => p.Client).Include(p => p.Designer);
            return View(await NBDContext.ToListAsync());
        }

        // GET: Bid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Designer)
                .Include(p => p.LabourSummaries).ThenInclude(l => l.EmployeeType)
                .Include(p => p.ProjectMaterials).ThenInclude(i => i.Inventory).ThenInclude(m => m.Material)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Bid/Create
        public IActionResult Create()
        {
            var project = new Project();
            project.LabourSummaries = new List<LabourSummary>();
            project.CurrentPhase = "Bid";
            PopulateAssignedEmployeeTypes(project);
            PopulateAssignedMaterials(project);
            PopulateDropDownLists(project);
            return View();
        }

        // POST: Bid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Desc,EstCost,BidDate,EstStartDate,EstFinishDate,Cost,BidCustApproved,BidManagementApproved,ClientID,DesignerID")] Project project, string[] selectedLabOptions, string[] selectedLabQuantity, string[] selectedMatOptions, string[] selectedMatQuantity)
        {
            try
            {
                int ctr = 0;
                int a = 0;
                //Add the selected conditions
                if (selectedLabOptions != null)
                {
                    project.LabourSummaries = new List<LabourSummary>();
                    foreach (var employeeType in selectedLabOptions)
                    {
                        var employeeTypeToAdd = new LabourSummary { ProjectID = project.ID, EmployeeTypeID = int.Parse(employeeType), Hours = int.Parse(selectedLabQuantity[ctr])};
                        project.LabourSummaries.Add(employeeTypeToAdd);
                        ctr++;
                    }
                }

                if (selectedMatOptions != null)
                {
                    project.ProjectMaterials = new List<ProjectMaterials>();
                    
                    foreach (var inventory in selectedMatOptions)
                    {
                        var inventoryToAdd = new ProjectMaterials { ProjectID = project.ID, InventoryID = int.Parse(inventory), MatEstQty = int.Parse(selectedMatQuantity[a]) };
                        project.ProjectMaterials.Add(inventoryToAdd);
                        a++;
                    }
                }

                if (ModelState.IsValid)
                {
                    _context.Add(project);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unknown error!");
            }

            PopulateAssignedEmployeeTypes(project);
            PopulateAssignedMaterials(project);
            PopulateDropDownLists(project);
            return View(project);
        }

        // GET: Bid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Designer)
                .Include(p => p.LabourSummaries).ThenInclude(l => l.EmployeeType)
                .Include(p => p.ProjectMaterials).ThenInclude(i => i.Inventory).ThenInclude(m => m.Material)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            PopulateAssignedEmployeeTypes(project);
            PopulateAssignedMaterials(project);
            PopulateDropDownLists(project);
            return View(project);
        }

        // POST: Bid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedLabOptions, string[] selectedLabQuantity, string[] selectedMatOptions, string[] selectedMatQuantity)
        {
            var projectToUpdate = await _context.Projects
            .Include(p => p.Client)
            .Include(p => p.Designer)
            .Include(p => p.LabourSummaries).ThenInclude(l => l.EmployeeType)
            .Include(p => p.ProjectMaterials).ThenInclude(i => i.Inventory).ThenInclude(m => m.Material)
            .SingleOrDefaultAsync(p => p.ID == id);

            if (projectToUpdate == null)
            {
                return NotFound();
            }
            
            UpdateEmployeeTypes(selectedLabOptions, selectedLabQuantity, projectToUpdate);
            UpdateMaterials(selectedMatOptions, selectedMatQuantity, projectToUpdate);

            if (await TryUpdateModelAsync<Project>(projectToUpdate, "",
                p => p.Name, p => p.Desc, p => p.EstCost, p => p.BidDate, p => p.EstStartDate,
                p => p.EstFinishDate, p => p.BidCustApproved, p => p.BidManagementApproved, p => p.ClientID, p => p.DesignerID))
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

            PopulateAssignedEmployeeTypes(projectToUpdate);
            PopulateAssignedMaterials(projectToUpdate);
            PopulateDropDownLists(projectToUpdate);
            return View(projectToUpdate);
        }

        // GET: Bid/Delete/5
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

        // POST: Bid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDropDownLists(Project project = null)
        {
            ViewData["ClientID"] = new SelectList(_context
                .Clients
                .OrderBy(c => c.Name), "ID", "Name", project?.ClientID);
            ViewData["DesignerID"] = new SelectList(_context
                .Set<Employee>()
                .OrderBy(e => e.FullName), "ID", "FullName", project?.DesignerID);
        }

        private void PopulateAssignedEmployeeTypes(Project project)
        {
            var allEmployeeTypes = _context.EmployeeTypes;
            var pEmployeeTypes = new HashSet<int>(project.LabourSummaries.Select(b => b.EmployeeTypeID));
            var pEmployeeHours = new HashSet<LabourSummary>(project.LabourSummaries);
            var checkBoxes = new List<OptionVM>();
            
            foreach (var employeeType in allEmployeeTypes)
            {
                int hour = 0;
                if(pEmployeeTypes.Contains(employeeType.ID))
                {
                    var hours = project.LabourSummaries.FirstOrDefault(p => p.EmployeeTypeID == employeeType.ID);
                    hour = hours.Hours;
                }
                
                checkBoxes.Add(new OptionVM
                {
                    ID = employeeType.ID,
                    DisplayText = employeeType.Type,
                    Quantity = hour,
                    Assigned = pEmployeeTypes.Contains(employeeType.ID)
                });
            }
            ViewData["EmployeeTypes"] = checkBoxes;
        }

        private void UpdateEmployeeTypes(string[] selectedOptions, string[] selectedQuantity, Project projectToUpdate)
        {
            if (selectedOptions == null)
            {
                projectToUpdate.LabourSummaries = new List<LabourSummary>();
                return;
            }


            int ctr = 0;

            var selectedEmployeeTypeHS = new HashSet<string>(selectedOptions);
            var selectedEmployeeTypeHoursHS = new HashSet<string>(selectedQuantity);
            var LabourSummariesHS = new HashSet<int>
                (projectToUpdate.LabourSummaries.Select(c => c.EmployeeTypeID));

            foreach (var employeeType in _context.EmployeeTypes)
            {
                if (selectedEmployeeTypeHS.Contains(employeeType.ID.ToString()))
                {
                    if (LabourSummariesHS.Contains(employeeType.ID))
                    {
                        LabourSummary employeeTypeToRemove = projectToUpdate.LabourSummaries.SingleOrDefault(c => c.EmployeeTypeID == employeeType.ID);
                        _context.Remove(employeeTypeToRemove);
                        projectToUpdate.LabourSummaries.Add(new LabourSummary { ProjectID = projectToUpdate.ID, EmployeeTypeID = employeeType.ID, Hours = int.Parse(selectedQuantity[ctr]) });
                    }
                    if (!LabourSummariesHS.Contains(employeeType.ID))
                    {
                        projectToUpdate.LabourSummaries.Add(new LabourSummary { ProjectID = projectToUpdate.ID, EmployeeTypeID = employeeType.ID, Hours = int.Parse(selectedQuantity[ctr]) });
                    }
                    ctr++;
                }
                else
                {
                    if (LabourSummariesHS.Contains(employeeType.ID))
                    {
                        LabourSummary employeeTypeToRemove = projectToUpdate.LabourSummaries.SingleOrDefault(c => c.EmployeeTypeID == employeeType.ID);
                        _context.Remove(employeeTypeToRemove);
                    }
                }
            }
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
        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBDv2.Data;
using NBDv2.Models;
using NBDv2.ViewModel;

namespace NBDv2.Controllers
{
    [Authorize(Roles = "Admin, Designer, Design Manager, Worker, Work Manager")]
    public class ProjectsController : Controller
    {
        private readonly NBDContext _context;

        public ProjectsController(NBDContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var NBDContext = _context.Projects.Include(p => p.Client).Include(p => p.Designer).Where(p => p.BidCustApproved == true && p.BidManagementApproved == true);
            return View(await NBDContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
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

        public async Task<IActionResult> DailyReport(int? id, DateTime? date)
        {
            if (id == null)
            {
                return NotFound();
            }


            var mat = from s in _context.ProjectMaterials.Include(p => p.Inventory).ThenInclude(i => i.Material)
                        where s.ProjectID == id && s.MatInstall == date
                        select s;

            var lab = from s in _context.Labours
                    .Include(l => l.Team).ThenInclude(t => t.Employees)
                    .Include(l => l.Task)
                        where s.Team.ProjectID == id && s.StartDate == date
                        select s;

            ViewData["Date"] = date;
            

            var project = await _context.Projects.FirstOrDefaultAsync(m => m.ID == id);

            if (project == null)
            {
                return NotFound();
            }
            PopulateDateDDL(id);
            return View(project);
        }


        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(project);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Desc,EstCost,BidDate,EstStartDate,EstFinishDate,StartDate,FinishDate,Cost,BidCustApproved,BidManagementApproved,ClientID,DesignerID")] Project project)
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
            PopulateDropDownLists(project);
            return View(project);
        }

        public async Task<IActionResult> EditMaterials(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(project);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMaterials(int id, [Bind("ID,Name,Desc,EstCost,BidDate,EstStartDate,EstFinishDate,StartDate,FinishDate,Cost,BidCustApproved,BidManagementApproved,ClientID,DesignerID")] Project project)
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
            PopulateDropDownLists(project);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
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

        private void PopulateDropDownLists(Project project = null)
        {
            ViewData["ClientID"] = new SelectList(_context
                .Clients
                .OrderBy(c => c.Name), "ID", "Name", project?.ClientID);
            ViewData["DesignerID"] = new SelectList(_context
                .Set<Employee>()
                .OrderBy(e => e.FullName), "ID", "FullName", project?.DesignerID);
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
                        ProjectEmployee specToRemove = projectToUpdate.ProjectEmployees.SingleOrDefault(d => d.EmployeeID == s.ID);
                        _context.Remove(specToRemove);
                    }
                }
            }
        }

        public PartialViewResult ProdReportMaterials(Project project, DateTime? filterDate)
        {
            var query = from s in _context.ProjectMaterials.Include(p => p.Inventory).ThenInclude(i => i.Material)

                        select s;
            if (filterDate != null)
            {
                query = from s in _context.ProjectMaterials.Include(p => p.Inventory).ThenInclude(i => i.Material)
                            where s.ProjectID == project.ID && s.MatInstall == filterDate
                            select s;
            }
            
                
            
            
            return PartialView("_ListOfMaterials", query.ToList());
        }

        public PartialViewResult ProdReportLabours(int id, DateTime filterDate)
        {
            var query = from s in _context.Labours
                    .Include(l => l.Team).ThenInclude(t => t.Employees)
                    .Include(l => l.Task)
                    where s.Team.ProjectID == id && s.StartDate == filterDate
                    select s;

            return PartialView("_LabourList", query.ToList());
        }

        private void PopulateDateDDL(int? id)
        {
           var a = from s in _context.Projects
                              .Include(p => p.ProjectEmployees).ThenInclude(p => p.Labours)
                              where s.ID == id
                              select s.StartDate;
            Project project = _context.Projects.Include(p => p.ProjectEmployees).ThenInclude(pe => pe.Labours).FirstOrDefault(p => p.ID == id);
            HashSet <DateTime> dates = new HashSet<DateTime>(project.ProjectMaterials.Select(pm => pm.MatInstall.Date));
            foreach(DateTime d in a)
            {
                dates.Add(d.Date);
            }
            ViewData["Dates"] = new SelectList(dates.OrderBy(d => d.Date), dates.FirstOrDefault());
        }


        private void PopulateMaterials(Project project)
        {
            var plants = _context.Materials.Where(i => i.Type == "Plant");
            var pottery = _context.Materials.Where(i => i.Type == "Pottery");
            var material = _context.Materials.Where(i => i.Type == "Material");
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
                    DisplayText = plant.Desc,
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
                    DisplayText = pot.Desc,
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
                    DisplayText = mat.Desc,
                    Assigned = pInventory.Contains(mat.ID)
                });
            }
            ViewData["Plants"] = plantCheckBoxes;
            ViewData["Pottery"] = potteryCheckBoxes;
            ViewData["Materials"] = matCheckBoxes;
        }
    }
}

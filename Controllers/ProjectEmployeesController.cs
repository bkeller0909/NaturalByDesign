using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBDv2.Data;
using NBDv2.Models;
using NBDv2.ViewModel;

namespace NBDv2.Controllers
{
    public class ProjectEmployeesController : Controller
    {
        private readonly NBDContext _context;

        public ProjectEmployeesController(NBDContext context)
        {
            _context = context;
        }

        // GET: ProjectEmployees
        public async Task<IActionResult> Index(int? ProjectID)
        {
            if (!ProjectID.HasValue)
            {
                //Can't work without a patient so go back to Patient Index
                return RedirectToAction("Index", "Project");
            }

            var team = from a in _context.ProjectEmployees
                       .Include(p => p.Employee)
                       .Include(p => p.Project)
                       where a.ProjectID == ProjectID.GetValueOrDefault()
                       select a;

            Project project = _context.Projects.Where(p => p.ID == ProjectID.GetValueOrDefault()).FirstOrDefault();
            ViewBag.Project = project;

            return View(await team.ToListAsync());
        }



        // GET: ProjectEmployees/Create
        public IActionResult Add(int? ProjectID)
        {
            if (!ProjectID.HasValue)
            {
                return RedirectToAction("Index", "Projects");
            }
            PopulateDropdownLists(ProjectID);
            ProjectEmployee a = new ProjectEmployee()
            {
                ProjectID = ProjectID.GetValueOrDefault()
            };

            return View(a);
        }

        // POST: ProjectEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,ProjectID,EmployeeID")] ProjectEmployee projectEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(projectEmployee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { projectEmployee.ProjectID });
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            PopulateDropdownLists(projectEmployee.ProjectID);
            return View(projectEmployee);
        }

        // GET: ProjectEmployees/Delete/5
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployees
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            return View(projectEmployee);
        }

        // POST: ProjectEmployees/Delete/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var projectEmployee = await _context.ProjectEmployees.FirstOrDefaultAsync(m => m.ID == id);


            try
            {
                _context.ProjectEmployees.Remove(projectEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { projectEmployee.ProjectID });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(projectEmployee);
        }

        private bool ProjectEmployeeExists(int id)
        {
            return _context.ProjectEmployees.Any(e => e.ID == id);
        }

        private void PopulateDropdownLists(int? id)
        {
            var allEmployees = _context.Employees;
            var team = from a in _context.ProjectEmployees
                       where a.ProjectID == id.GetValueOrDefault()
                       select a.EmployeeID;
            var unassignedEmployees = new List<OptionVM>();

            foreach (var employee in allEmployees)
            {
                if (!team.Contains(employee.ID))
                {
                    unassignedEmployees.Add(new OptionVM { ID = employee.ID, DisplayText = employee.FullName });
                }
            }
            ViewData["Employees"] = new SelectList(unassignedEmployees.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }
    }
}

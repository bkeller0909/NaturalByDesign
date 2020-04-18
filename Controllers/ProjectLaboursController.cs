using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBDv2.Data;
using NBDv2.Models;

namespace NBDv2.Controllers
{
    public class ProjectLaboursController : Controller
    {
        private readonly NBDContext _context;

        public ProjectLaboursController(NBDContext context)
        {
            _context = context;
        }

        // GET: ProjectLabours
        public async Task<IActionResult> Index(int? ProjectID)
        {
            if(!ProjectID.HasValue)
            {
                return RedirectToAction("Details", "ProjectPlan");
            }

            var labours = from l in _context.Labours
                          .Include(l => l.Task)
                          .Include(e => e.Team)
                          where l.Team.ProjectID == ProjectID
                          select l;

            //if(teamID.HasValue)
            //{
            //    labours = labours.Where(l => l.Team.ID == teamID);
            //}

            Project project = _context.Projects
                .Include(p => p.Designer)
                .Include(p => p.Client)
                .Where(p => p.ID == ProjectID.GetValueOrDefault()).FirstOrDefault();
            ViewBag.Projects = project;
            PopulateDDl(project.ID);
            return View(await labours.ToListAsync());
        }

        

        // GET: ProjectLabours/Create
        public IActionResult Add(int? ProjectID)
        {
            if(ProjectID == null)
            {

            }

            return View();
        }

        // POST: ProjectLabours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,EstStartDate,StartDate,EstHours,Hours,TeamID,TaskID")] Labour labour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //PopulateDDl(labour);
            return View(labour);
        }

        // GET: ProjectLabours/Edit/5
        public async Task<IActionResult> Update(int? ProjectID, int?LabourID)
        {
            if (ProjectID == null)
            {
                return NotFound();
            }

            var labour = await _context.Labours.Include(l => l.Task).FirstOrDefaultAsync(l => l.ID == LabourID);
            if (labour == null)
            {
                return NotFound();
            }
            PopulateDDl(ProjectID.Value, labour);
            return View(labour);
        }

        // POST: ProjectLabours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("ID,EstStartDate,StartDate,EstHours,Hours,TeamID,TaskID")] Labour labour)
        {
            if (id != labour.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabourExists(labour.ID))
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
            //PopulateDDl(labour);
            return View(labour);
        }

        // GET: ProjectLabours/Delete/5
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labours
                .Include(l => l.Task)
                .Include(l => l.Team)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labour == null)
            {
                return NotFound();
            }

            return View(labour);
        }

        // POST: ProjectLabours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var labour = await _context.Labours.FindAsync(id);
            _context.Labours.Remove(labour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabourExists(int id)
        {
            return _context.Labours.Any(e => e.ID == id);
        }

        private void PopulateDDl(int projectID, Labour labour = null)
        {
            ViewData["TaskID"] = new SelectList(_context.Tasks, "ID", "Desc", labour?.TaskID);
            ViewData["TeamID"] = new SelectList(_context.ProjectEmployees.Include(p => p.Employee).Where(p => p.ProjectID == projectID), "ID", "Employee.FullName", labour?.TeamID);
        }
    }
}

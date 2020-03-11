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
    public class ProjectEmployeeController : Controller
    {
        private readonly NBDContext _context;

        public ProjectEmployeeController(NBDContext context)
        {
            _context = context;
        }

        // GET: ProjectEmployee
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.ProjectEmployees.Include(p => p.Employee).Include(p => p.Project);
            return View(await nBDContext.ToListAsync());
        }

        // GET: ProjectEmployee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployees
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            return View(projectEmployee);
        }

        // GET: ProjectEmployee/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name");
            return View();
        }

        // POST: ProjectEmployee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,EmployeeID")] ProjectEmployee projectEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "FirstName", projectEmployee.EmployeeID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", projectEmployee.ProjectID);
            return View(projectEmployee);
        }

        // GET: ProjectEmployee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployees.FindAsync(id);
            if (projectEmployee == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "FirstName", projectEmployee.EmployeeID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", projectEmployee.ProjectID);
            return View(projectEmployee);
        }

        // POST: ProjectEmployee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectID,EmployeeID")] ProjectEmployee projectEmployee)
        {
            if (id != projectEmployee.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectEmployeeExists(projectEmployee.ProjectID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "FirstName", projectEmployee.EmployeeID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", projectEmployee.ProjectID);
            return View(projectEmployee);
        }

        // GET: ProjectEmployee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployees
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            return View(projectEmployee);
        }

        // POST: ProjectEmployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectEmployee = await _context.ProjectEmployees.FindAsync(id);
            _context.ProjectEmployees.Remove(projectEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectEmployeeExists(int id)
        {
            return _context.ProjectEmployees.Any(e => e.ProjectID == id);
        }
    }
}

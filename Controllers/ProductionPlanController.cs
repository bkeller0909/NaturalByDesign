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
            ViewData["DesignerID"] = new SelectList(_context.Employees, "Id", "FirstName");
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
            ViewData["DesignerID"] = new SelectList(_context.Employees, "Id", "FirstName", project.DesignerID);
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
                .Include(p => p.ProjectEmployees).ThenInclude(p => p.Employee)
                .Include(p => p.ProjectMaterials).ThenInclude(p => p.Inventory)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ID == id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ConFirst", project.ClientID);
            ViewData["DesignerID"] = new SelectList(_context.Employees, "Id", "FirstName", project.DesignerID);
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
            ViewData["DesignerID"] = new SelectList(_context.Employees, "Id", "FirstName", project.DesignerID);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBDv2.Data;
using NBDv2.Models;

namespace NBDv2.Controllers
{
    [Authorize(Roles = "Admin, Designer, Design Manager, Worker, Work Manager")]
    public class ProjectMaterialsController : Controller
    {
        private readonly NBDContext _context;

        public ProjectMaterialsController(NBDContext context)
        {
            _context = context;
        }

        // GET: ProjectMaterials
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.ProjectMaterials.Include(p => p.Inventory).Include(p => p.Project);
            return View(await nBDContext.ToListAsync());
        }

        // GET: ProjectMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMaterials = await _context.ProjectMaterials
                .Include(p => p.Inventory)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (projectMaterials == null)
            {
                return NotFound();
            }

            return View(projectMaterials);
        }

        // GET: ProjectMaterials/Create
        public IActionResult Create()
        {
            ViewData["InventoryID"] = new SelectList(_context.Inventories, "ID", "ID");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc");
            return View();
        }

        // POST: ProjectMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,InventoryID,MatDelivery,MatInstall,MatEstQty,MatActQty")] ProjectMaterials projectMaterials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectMaterials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventories, "ID", "ID", projectMaterials.InventoryID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", projectMaterials.ProjectID);
            return View(projectMaterials);
        }

        // GET: ProjectMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMaterials = await _context.ProjectMaterials.FindAsync(id);
            if (projectMaterials == null)
            {
                return NotFound();
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventories, "ID", "ID", projectMaterials.InventoryID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", projectMaterials.ProjectID);
            return View(projectMaterials);
        }

        // POST: ProjectMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectID,InventoryID,MatDelivery,MatInstall,MatEstQty,MatActQty")] ProjectMaterials projectMaterials)
        {
            if (id != projectMaterials.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectMaterials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectMaterialsExists(projectMaterials.ProjectID))
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
            ViewData["InventoryID"] = new SelectList(_context.Inventories, "ID", "ID", projectMaterials.InventoryID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", projectMaterials.ProjectID);
            return View(projectMaterials);
        }

        // GET: ProjectMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMaterials = await _context.ProjectMaterials
                .Include(p => p.Inventory)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (projectMaterials == null)
            {
                return NotFound();
            }

            return View(projectMaterials);
        }

        // POST: ProjectMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectMaterials = await _context.ProjectMaterials.FindAsync(id);
            _context.ProjectMaterials.Remove(projectMaterials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectMaterialsExists(int id)
        {
            return _context.ProjectMaterials.Any(e => e.ProjectID == id);
        }
    }
}

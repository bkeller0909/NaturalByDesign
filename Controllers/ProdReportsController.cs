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
    public class ProdReportsController : Controller
    {
        private readonly NBDContext _context;

        public ProdReportsController(NBDContext context)
        {
            _context = context;
        }

        // GET: ProdReports
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.ProdReport.Include(p => p.Project);
            return View(await nBDContext.ToListAsync());
        }

        // GET: ProdReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodReport = await _context.ProdReport
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prodReport == null)
            {
                return NotFound();
            }

            return View(prodReport);
        }

        // GET: ProdReports/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name");
            return View();
        }

        // POST: ProdReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProjectID,Date")] ProdReport prodReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", prodReport.ProjectID);
            return View(prodReport);
        }

        // GET: ProdReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodReport = await _context.ProdReport.FindAsync(id);
            if (prodReport == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", prodReport.ProjectID);
            return View(prodReport);
        }

        // POST: ProdReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProjectID,Date")] ProdReport prodReport)
        {
            if (id != prodReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdReportExists(prodReport.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", prodReport.ProjectID);
            return View(prodReport);
        }

        // GET: ProdReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodReport = await _context.ProdReport
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prodReport == null)
            {
                return NotFound();
            }

            return View(prodReport);
        }

        // POST: ProdReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodReport = await _context.ProdReport.FindAsync(id);
            _context.ProdReport.Remove(prodReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdReportExists(int id)
        {
            return _context.ProdReport.Any(e => e.ID == id);
        }
    }
}

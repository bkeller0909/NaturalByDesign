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
    public class ProductionWorkReportsController : Controller
    {
        private readonly NBDContext _context;

        public ProductionWorkReportsController(NBDContext context)
        {
            _context = context;
        }

        // GET: ProductionWorkReports
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.ProductionWorkReports.Include(p => p.Project);
            return View(await nBDContext.ToListAsync());
        }

        // GET: ProductionWorkReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionWorkReport = await _context.ProductionWorkReports
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionWorkReport == null)
            {
                return NotFound();
            }

            return View(productionWorkReport);
        }

        // GET: ProductionWorkReports/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc");
            return View();
        }

        // POST: ProductionWorkReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Submitter,SubmissionDate,ProjectID")] ProductionWorkReport productionWorkReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionWorkReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", productionWorkReport.ProjectID);
            return View(productionWorkReport);
        }

        // GET: ProductionWorkReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionWorkReport = await _context.ProductionWorkReports.FindAsync(id);
            if (productionWorkReport == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", productionWorkReport.ProjectID);
            return View(productionWorkReport);
        }

        // POST: ProductionWorkReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Submitter,SubmissionDate,ProjectID")] ProductionWorkReport productionWorkReport)
        {
            if (id != productionWorkReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionWorkReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionWorkReportExists(productionWorkReport.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", productionWorkReport.ProjectID);
            return View(productionWorkReport);
        }

        // GET: ProductionWorkReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionWorkReport = await _context.ProductionWorkReports
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionWorkReport == null)
            {
                return NotFound();
            }

            return View(productionWorkReport);
        }

        // POST: ProductionWorkReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionWorkReport = await _context.ProductionWorkReports.FindAsync(id);
            _context.ProductionWorkReports.Remove(productionWorkReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionWorkReportExists(int id)
        {
            return _context.ProductionWorkReports.Any(e => e.ID == id);
        }
    }
}

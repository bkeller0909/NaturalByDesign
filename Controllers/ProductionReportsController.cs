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
    [Authorize(Roles = "Admin, Worker, Work Manager")]
    public class ProductionReportsController : Controller
    {
        private readonly NBDContext _context;

        public ProductionReportsController(NBDContext context)
        {
            _context = context;
        }

        // GET: ProductionReports
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.ProductionReports.Include(p => p.Project);
            return View(await nBDContext.ToListAsync());
        }

        // GET: ProductionReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionReport = await _context.ProductionReports
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionReport == null)
            {
                return NotFound();
            }

            return View(productionReport);
        }

        // GET: ProductionReports/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc");
            return View();
        }

        // POST: ProductionReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BidCost,EstCost,TotalCost,ActualMtlCost,EstMtlCost,ActualLabourProdCost,EstLabourProdCost,ActualDesignCost,EstDesignCost,ProjectID")] ProductionReport productionReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", productionReport.ProjectID);
            return View(productionReport);
        }

        // GET: ProductionReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionReport = await _context.ProductionReports.FindAsync(id);
            if (productionReport == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", productionReport.ProjectID);
            return View(productionReport);
        }

        // POST: ProductionReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BidCost,EstCost,TotalCost,ActualMtlCost,EstMtlCost,ActualLabourProdCost,EstLabourProdCost,ActualDesignCost,EstDesignCost,ProjectID")] ProductionReport productionReport)
        {
            if (id != productionReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionReportExists(productionReport.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", productionReport.ProjectID);
            return View(productionReport);
        }

        // GET: ProductionReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionReport = await _context.ProductionReports
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionReport == null)
            {
                return NotFound();
            }

            return View(productionReport);
        }

        // POST: ProductionReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionReport = await _context.ProductionReports.FindAsync(id);
            _context.ProductionReports.Remove(productionReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionReportExists(int id)
        {
            return _context.ProductionReports.Any(e => e.ID == id);
        }
    }
}

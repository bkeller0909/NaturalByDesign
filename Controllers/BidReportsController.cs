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
    [Authorize(Roles = "Admin, Designer, Design Manager")]
    public class BidReportsController : Controller
    {
        private readonly NBDContext _context;

        public BidReportsController(NBDContext context)
        {
            _context = context;
        }

        // GET: BidReports
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.BidReport.Include(b => b.Project);
            return View(await nBDContext.ToListAsync());
        }

        // GET: BidReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidReport = await _context.BidReport
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidReport == null)
            {
                return NotFound();
            }

            return View(bidReport);
        }

        // GET: BidReports/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc");
            return View();
        }

        // POST: BidReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EstBid,ActlHours,EstHours,ActlCosts,EstCost,HoursRemaining,CostsRemaining,ProjectID")] BidReport bidReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bidReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", bidReport.ProjectID);
            return View(bidReport);
        }

        // GET: BidReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidReport = await _context.BidReport.FindAsync(id);
            if (bidReport == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", bidReport.ProjectID);
            return View(bidReport);
        }

        // POST: BidReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EstBid,ActlHours,EstHours,ActlCosts,EstCost,HoursRemaining,CostsRemaining,ProjectID")] BidReport bidReport)
        {
            if (id != bidReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidReportExists(bidReport.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", bidReport.ProjectID);
            return View(bidReport);
        }

        // GET: BidReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidReport = await _context.BidReport
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidReport == null)
            {
                return NotFound();
            }

            return View(bidReport);
        }

        // POST: BidReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bidReport = await _context.BidReport.FindAsync(id);
            _context.BidReport.Remove(bidReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidReportExists(int id)
        {
            return _context.BidReport.Any(e => e.ID == id);
        }
    }
}

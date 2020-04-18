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
    public class DesignDaysController : Controller
    {
        private readonly NBDContext _context;

        public DesignDaysController(NBDContext context)
        {
            _context = context;
        }

        // GET: DesignDays
        public async Task<IActionResult> Index()
        {
            var nBDContext = _context.DesignDay.Include(d => d.Project);
            return View(await nBDContext.ToListAsync());
        }

        // GET: DesignDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designDay = await _context.DesignDay
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (designDay == null)
            {
                return NotFound();
            }

            return View(designDay);
        }

        // GET: DesignDays/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc");
            return View();
        }

        // POST: DesignDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Stage,Hours,Task,Submitter,SubmissionDate,ProjectID")] DesignDay designDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", designDay.ProjectID);
            return View(designDay);
        }

        // GET: DesignDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designDay = await _context.DesignDay.FindAsync(id);
            if (designDay == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", designDay.ProjectID);
            return View(designDay);
        }

        // POST: DesignDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Stage,Hours,Task,Submitter,SubmissionDate,ProjectID")] DesignDay designDay)
        {
            if (id != designDay.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignDayExists(designDay.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Desc", designDay.ProjectID);
            return View(designDay);
        }

        // GET: DesignDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designDay = await _context.DesignDay
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (designDay == null)
            {
                return NotFound();
            }

            return View(designDay);
        }

        // POST: DesignDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designDay = await _context.DesignDay.FindAsync(id);
            _context.DesignDay.Remove(designDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignDayExists(int id)
        {
            return _context.DesignDay.Any(e => e.ID == id);
        }
    }
}

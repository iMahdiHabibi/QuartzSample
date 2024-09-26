using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuartzSample.Data;
using QuartzSample.Models;

namespace QuartzSample.Controllers
{
    public class SetsController : Controller
    {
        private readonly Context _context;

        public SetsController(Context context)
        {
            _context = context;
        }

        // GET: Sets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Set.ToListAsync());
        }

        // GET: Sets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Set
                .FirstOrDefaultAsync(m => m.K == id);
            if (@set == null)
            {
                return NotFound();
            }

            return View(@set);
        }

        // GET: Sets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sets/Create
        // To protect from overPosting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("K,V")] Set @set)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@set);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@set);
        }

        // GET: Sets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Set.FindAsync(id);
            if (@set == null)
            {
                return NotFound();
            }
            return View(@set);
        }

        // POST: Sets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("K,V")] Set @set)
        {
            if (id != @set.K)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@set);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetExists(@set.K))
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
            return View(@set);
        }

        // GET: Sets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Set
                .FirstOrDefaultAsync(m => m.K == id);
            if (@set == null)
            {
                return NotFound();
            }

            return View(@set);
        }

        // POST: Sets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var @set = await _context.Set.FindAsync(id);
            if (@set != null)
            {
                _context.Set.Remove(@set);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetExists(string id)
        {
            return _context.Set.Any(e => e.K == id);
        }
    }
}

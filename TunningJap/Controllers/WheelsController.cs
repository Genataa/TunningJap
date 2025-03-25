using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TunningJap.Data;

namespace TunningJap.Controllers
{
    
    public class WheelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WheelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wheels
        public async Task<IActionResult> Index()
        {
              return _context.Wheels != null ? 
                          View(await _context.Wheels.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Wheels'  is null.");
        }

        // GET: Wheels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wheels == null)
            {
                return NotFound();
            }

            var wheels = await _context.Wheels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wheels == null)
            {
                return NotFound();
            }

            return View(wheels);
        }

        // GET: Wheels/Create

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wheels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

       
        public async Task<IActionResult> Create([Bind("Name,Description,ImagePath,Id")] Wheels wheels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wheels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wheels);
        }

        // GET: Wheels/Edit/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wheels == null)
            {
                return NotFound();
            }

            var wheels = await _context.Wheels.FindAsync(id);
            if (wheels == null)
            {
                return NotFound();
            }
            return View(wheels);
        }

        // POST: Wheels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImagePath,Id")] Wheels wheels)
        {
            if (id != wheels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wheels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WheelsExists(wheels.Id))
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
            return View(wheels);
        }

        // GET: Wheels/Delete/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wheels == null)
            {
                return NotFound();
            }

            var wheels = await _context.Wheels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wheels == null)
            {
                return NotFound();
            }

            return View(wheels);
        }

        // POST: Wheels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wheels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Wheels'  is null.");
            }
            var wheels = await _context.Wheels.FindAsync(id);
            if (wheels != null)
            {
                _context.Wheels.Remove(wheels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WheelsExists(int id)
        {
          return (_context.Wheels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

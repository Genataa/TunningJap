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
    public class exhaustsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public exhaustsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: exhausts
        public async Task<IActionResult> Index()
        {
              return _context.exhaust != null ? 
                          View(await _context.exhaust.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.exhaust'  is null.");
        }

        // GET: exhausts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.exhaust == null)
            {
                return NotFound();
            }

            var exhaust = await _context.exhaust
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exhaust == null)
            {
                return NotFound();
            }

            return View(exhaust);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: exhausts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ImagePath,Id")] exhaust exhaust)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhaust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exhaust);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.exhaust == null)
            {
                return NotFound();
            }

            var exhaust = await _context.exhaust.FindAsync(id);
            if (exhaust == null)
            {
                return NotFound();
            }
            return View(exhaust);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImagePath,Id")] exhaust exhaust)
        {
            if (id != exhaust.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhaust);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!exhaustExists(exhaust.Id))
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
            return View(exhaust);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.exhaust == null)
            {
                return NotFound();
            }

            var exhaust = await _context.exhaust
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exhaust == null)
            {
                return NotFound();
            }

            return View(exhaust);
        }

        // POST: exhausts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.exhaust == null)
            {
                return Problem("Entity set 'ApplicationDbContext.exhaust'  is null.");
            }
            var exhaust = await _context.exhaust.FindAsync(id);
            if (exhaust != null)
            {
                _context.exhaust.Remove(exhaust);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool exhaustExists(int id)
        {
          return (_context.exhaust?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TunningJap.Data;

namespace TunningJap.Controllers
{
    public class CoiloversController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoiloversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Coilovers
        public async Task<IActionResult> Index()
        {
            return _context.Coilovers != null ?
                        View(await _context.Coilovers.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Coilovers'  is null.");
        }

        // GET: Coilovers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coilovers == null)
            {
                return NotFound();
            }

            var coilovers = await _context.Coilovers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coilovers == null)
            {
                return NotFound();
            }

            return View(coilovers);
        }

        // GET: Coilovers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coilovers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ImagePath,Id")] Coilovers coilovers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coilovers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coilovers);
        }

        // GET: Coilovers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Coilovers == null)
            {
                return NotFound();
            }

            var coilovers = await _context.Coilovers.FindAsync(id);
            if (coilovers == null)
            {
                return NotFound();
            }
            return View(coilovers);
        }

        // POST: Coilovers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImagePath,Id")] Coilovers coilovers)
        {
            if (id != coilovers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coilovers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoiloversExists(coilovers.Id))
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
            return View(coilovers);
        }

        // GET: Coilovers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Coilovers == null)
            {
                return NotFound();
            }

            var coilovers = await _context.Coilovers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coilovers == null)
            {
                return NotFound();
            }

            return View(coilovers);
        }

        // POST: Coilovers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coilovers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Coilovers'  is null.");
            }
            var coilovers = await _context.Coilovers.FindAsync(id);
            if (coilovers != null)
            {
                _context.Coilovers.Remove(coilovers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoiloversExists(int id)
        {
            return (_context.Coilovers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
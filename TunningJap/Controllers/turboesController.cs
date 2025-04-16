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
    public class turboesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public turboesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: turboes
        public async Task<IActionResult> Index()
        {
              return _context.turbo != null ? 
                          View(await _context.turbo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.turbo'  is null.");
        }

        // GET: turboes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.turbo == null)
            {
                return NotFound();
            }

            var turbo = await _context.turbo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turbo == null)
            {
                return NotFound();
            }

            return View(turbo);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: turboes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ImagePath,Id")] turbo turbo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turbo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turbo);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.turbo == null)
            {
                return NotFound();
            }

            var turbo = await _context.turbo.FindAsync(id);
            if (turbo == null)
            {
                return NotFound();
            }
            return View(turbo);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImagePath,Id")] turbo turbo)
        {
            if (id != turbo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turbo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!turboExists(turbo.Id))
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
            return View(turbo);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.turbo == null)
            {
                return NotFound();
            }

            var turbo = await _context.turbo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turbo == null)
            {
                return NotFound();
            }

            return View(turbo);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.turbo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.turbo'  is null.");
            }
            var turbo = await _context.turbo.FindAsync(id);
            if (turbo != null)
            {
                _context.turbo.Remove(turbo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool turboExists(int id)
        {
          return (_context.turbo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

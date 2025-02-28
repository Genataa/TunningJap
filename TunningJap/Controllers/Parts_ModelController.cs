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
    public class Parts_ModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Parts_ModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parts_Model
        public async Task<IActionResult> Index()
        {
              return _context.Parts_Model != null ? 
                          View(await _context.Parts_Model.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Parts_Model'  is null.");
        }

        // GET: Parts_Model/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parts_Model == null)
            {
                return NotFound();
            }

            var parts_Model = await _context.Parts_Model
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parts_Model == null)
            {
                return NotFound();
            }

            return View(parts_Model);
        }

        // GET: Parts_Model/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parts_Model/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_model,ID_Parts,Id")] Parts_Model parts_Model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parts_Model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parts_Model);
        }

        // GET: Parts_Model/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parts_Model == null)
            {
                return NotFound();
            }

            var parts_Model = await _context.Parts_Model.FindAsync(id);
            if (parts_Model == null)
            {
                return NotFound();
            }
            return View(parts_Model);
        }

        // POST: Parts_Model/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_model,ID_Parts,Id")] Parts_Model parts_Model)
        {
            if (id != parts_Model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parts_Model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Parts_ModelExists(parts_Model.Id))
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
            return View(parts_Model);
        }

        // GET: Parts_Model/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parts_Model == null)
            {
                return NotFound();
            }

            var parts_Model = await _context.Parts_Model
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parts_Model == null)
            {
                return NotFound();
            }

            return View(parts_Model);
        }

        // POST: Parts_Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parts_Model == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Parts_Model'  is null.");
            }
            var parts_Model = await _context.Parts_Model.FindAsync(id);
            if (parts_Model != null)
            {
                _context.Parts_Model.Remove(parts_Model);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Parts_ModelExists(int id)
        {
          return (_context.Parts_Model?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

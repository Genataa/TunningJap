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
    public class ModelCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ModelCars
        public async Task<IActionResult> Index()
        {
              return _context.ModelCar != null ? 
                          View(await _context.ModelCar.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ModelCar'  is null.");
        }

        // GET: ModelCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelCar == null)
            {
                return NotFound();
            }

            var modelCar = await _context.ModelCar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelCar == null)
            {
                return NotFound();
            }

            return View(modelCar);
        }

        // GET: ModelCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameOfModel,Id_Brand,Id")] ModelCar modelCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelCar);
        }

        // GET: ModelCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelCar == null)
            {
                return NotFound();
            }

            var modelCar = await _context.ModelCar.FindAsync(id);
            if (modelCar == null)
            {
                return NotFound();
            }
            return View(modelCar);
        }

        // POST: ModelCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NameOfModel,Id_Brand,Id")] ModelCar modelCar)
        {
            if (id != modelCar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelCarExists(modelCar.Id))
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
            return View(modelCar);
        }

        // GET: ModelCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelCar == null)
            {
                return NotFound();
            }

            var modelCar = await _context.ModelCar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelCar == null)
            {
                return NotFound();
            }

            return View(modelCar);
        }

        // POST: ModelCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelCar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ModelCar'  is null.");
            }
            var modelCar = await _context.ModelCar.FindAsync(id);
            if (modelCar != null)
            {
                _context.ModelCar.Remove(modelCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelCarExists(int id)
        {
          return (_context.ModelCar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

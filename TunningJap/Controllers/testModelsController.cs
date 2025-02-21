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
    public class testModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public testModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: testModels
        public async Task<IActionResult> Index()
        {
              return _context.testModel != null ? 
                          View(await _context.testModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.testModel'  is null.");
        }

        // GET: testModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.testModel == null)
            {
                return NotFound();
            }

            var testModel = await _context.testModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // GET: testModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: testModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] testModel testModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testModel);
        }

        // GET: testModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.testModel == null)
            {
                return NotFound();
            }

            var testModel = await _context.testModel.FindAsync(id);
            if (testModel == null)
            {
                return NotFound();
            }
            return View(testModel);
        }

        // POST: testModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] testModel testModel)
        {
            if (id != testModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!testModelExists(testModel.Id))
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
            return View(testModel);
        }

        // GET: testModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.testModel == null)
            {
                return NotFound();
            }

            var testModel = await _context.testModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // POST: testModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.testModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.testModel'  is null.");
            }
            var testModel = await _context.testModel.FindAsync(id);
            if (testModel != null)
            {
                _context.testModel.Remove(testModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool testModelExists(int id)
        {
          return (_context.testModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

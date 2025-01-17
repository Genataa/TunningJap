using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunningJap.Data;
using TunningJap.Models;
using System.IO;
using System.Threading.Tasks;

namespace TunningJap.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        
        
        public async Task<IActionResult> Index()
        {
            
            var cars = await _context.Car.ToListAsync();
            return View(cars);
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Title,Image")] Car car)
        {
            if (ModelState.IsValid)
            {
                if (car.Image != null)
                {
                   
                    string fileName = Path.GetFileNameWithoutExtension(car.Image.FileName);
                    string extension = Path.GetExtension(car.Image.FileName);
                    string newFileName = fileName + "_" + Guid.NewGuid() + extension;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", newFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await car.Image.CopyToAsync(fileStream);
                    }

                   
                    car.ImagePath = "/images/" + newFileName;
                }

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Title,ImagePath,Image")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (car.Image != null)
                    {
                        
                        string fileName = Path.GetFileNameWithoutExtension(car.Image.FileName);
                        string extension = Path.GetExtension(car.Image.FileName);
                        string newFileName = fileName + "_" + Guid.NewGuid() + extension;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", newFileName);

                        
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await car.Image.CopyToAsync(fileStream);
                        }

                      
                        car.ImagePath = "/images/" + newFileName;
                    }

                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                
                if (car.ImagePath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, car.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Car.Remove(car);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}

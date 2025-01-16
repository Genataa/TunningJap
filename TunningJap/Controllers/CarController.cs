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

        // GET: Cars
        // GET: Cars
        public async Task<IActionResult> Index()
        {
            // Check if you are using async operations here, like database calls.
            // If you're not using any async operations, remove the 'async' keyword.
            var cars = await _context.Car.ToListAsync();
            return View(cars);
        }

        // GET: Cars/Details/5
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

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Title,Image")] Car car)
        {
            if (ModelState.IsValid)
            {
                if (car.Image != null)
                {
                    // Generate a unique filename for the image
                    string fileName = Path.GetFileNameWithoutExtension(car.Image.FileName);
                    string extension = Path.GetExtension(car.Image.FileName);
                    string newFileName = fileName + "_" + Guid.NewGuid() + extension;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", newFileName);

                    // Save the image to the "wwwroot/images" folder
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await car.Image.CopyToAsync(fileStream);
                    }

                    // Store the image path in the database
                    car.ImagePath = "/images/" + newFileName;
                }

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
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

        // POST: Cars/Edit/5
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
                    // If a new image is uploaded, save it
                    if (car.Image != null)
                    {
                        // Generate a unique filename for the image
                        string fileName = Path.GetFileNameWithoutExtension(car.Image.FileName);
                        string extension = Path.GetExtension(car.Image.FileName);
                        string newFileName = fileName + "_" + Guid.NewGuid() + extension;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", newFileName);

                        // Save the new image to the "wwwroot/images" folder
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await car.Image.CopyToAsync(fileStream);
                        }

                        // Update the image path in the database
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

        // GET: Cars/Delete/5
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

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                // Optional: Delete the image from the file system when deleting the car
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

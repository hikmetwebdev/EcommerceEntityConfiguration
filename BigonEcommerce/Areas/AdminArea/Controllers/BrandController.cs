using BigonEcommerce.Models.DataAcces;
using BigonEcommerce.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Areas.AdminArea.Controllers
{
    [Area (nameof (AdminArea))]
    public class BrandController : Controller
    {

        private readonly BigondbContext _context;

        public BrandController(BigondbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Brands.Where(x => x.DeletedBy == null).ToList());
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var brand = _context.Brands.Find(id);
            return View(brand);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand brand)
        {
            try
            {
                _context.Brands.Add(brand);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brand = _context.Brands.Find(id);

            return View(brand);
        }

        // POST: brandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Brand brand)
        {
            try
            {
                var editedbrand = _context.Brands.Find(id);
                editedbrand.Name = brand.Name;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult Remove(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var deletedbrand = _context.Brands.Find(id);
                if (deletedbrand is null)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Data is not available"
                    });
                }
                _context.Remove(deletedbrand);
                _context.SaveChanges();
                return Json(new
                {
                    error = false,
                    message = "Data has been deleted succesfully"
                });
            }
            catch
            {
                return View();
            }
        }
    }
}

using BigonEcommerce.Models.DataAcces;
using BigonEcommerce.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]

    public class ColorController : Controller
    {

        private readonly BigondbContext _context;

        public ColorController(BigondbContext context)
        {
            _context = context;
        }

        // GET: ColorController
        public IActionResult Index()
        {
            return View(_context.Colors.ToList());
        }

        // GET: ColorController/Details/5
        public IActionResult Details(int id)
        {
            if (id == null) return NotFound(); 
            var color=_context.Colors.FirstOrDefault(x=>x.Id == id);
            return View(color);
        }

        // GET: ColorController/Create
        public IActionResult Create()
        {
             
            return View();
        }

        // POST: ColorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Color color)
        {
            try
            {
                color.CreatedAt=DateTime.UtcNow;
                color.CreatedBy = 1;
                _context.Colors.Add(color);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return BadRequest("An error occurred while creating the color: " + ex.Message);
            }
        }

        // GET: ColorController/Edit/5
        public IActionResult Edit(int id)
        {
            var color=_context.Colors.FirstOrDefault(x=>x.Id==id);
          
            return View(color);
        }

        // POST: ColorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Color color)
        {
            if (color == null) return NotFound();
      
            try
            {
                var editedColor = _context.Colors.Find(color.Id);
                editedColor.Name = color.Name;
                editedColor.HexCode = color.HexCode;
                editedColor.ModifiedAt=DateTime.UtcNow;
                editedColor.ModifiedBy = 2;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

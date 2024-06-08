using BigonEcommerce.Data.DataAcces;
using Infrastructure.Entities;
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

        public IActionResult Index()
        {
            return View(_context.Colors.Where(x=>x.DeletedBy==null).ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound(); 
            var color=_context.Colors.FirstOrDefault(x=>x.Id == id);
            return View(color);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Color color)
        {
            try
            {
                _context.Colors.Add(color);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return BadRequest("An error occurred while creating the color: " + ex.Message);
            }
        }


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
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        [HttpPost]
        public IActionResult Remove(int id)
        {
            try
            {
                var deletedColor = _context.Colors.FirstOrDefault(color => color.Id == id);
                if (deletedColor is null)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Data is not available"
                    });
                }
                _context.Remove(deletedColor);
                _context.SaveChanges();
                var colors=_context.Colors.Where(x=>x.DeletedBy==null).ToList();

                return PartialView("_Body", colors);
            }
            catch
            {
                return View();
            }
        }
    }
}

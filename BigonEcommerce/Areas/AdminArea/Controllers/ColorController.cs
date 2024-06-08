using BigonEcommerce.Data.DataAcces;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]   

    public class ColorController : Controller
    {

        private readonly IColorRepository _colorRepository;

        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public IActionResult Index()
        {
           var colors=_colorRepository.GetAll(c=>c.DeletedBy==null);
            return View(colors);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var color = _colorRepository.Get(x => x.Id == id);
            return View();
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
                //_context.Colors.Add(color);
                //_context.SaveChanges();
                _colorRepository.Add(color);
                _colorRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return BadRequest("An error occurred while creating the color: " + ex.Message);
            }
        }


        public IActionResult Edit(int id)
        {
            var color = _colorRepository.Get(x=>x.Id==id);
          
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
                _colorRepository.Edit(color);
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
                var deletedColor = _colorRepository.Get(x => x.Id == id);
                if (deletedColor is null)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Data is not available"
                    });
                }
                _colorRepository.Remove(deletedColor);
                _colorRepository.Save();
                var colors=_colorRepository.GetAll(x=>x.DeletedBy==null);

                return PartialView("_Body", colors);
            }
            catch
            {
                return View();
            }
        }
    }
}

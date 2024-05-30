using BigonEcommerce.Models.DataAcces;
using BigonEcommerce.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Areas.AdminArea.Controllers
{
    [Area (nameof(AdminArea))]
    public class TagController : Controller
    {
        private readonly BigondbContext _context;

        public TagController(BigondbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Tags.Where(x => x.DeletedBy == null).ToList());
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var tag=  _context.Tags.Find(id);
            return View(tag);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            try
            {
                _context.Tags.Add(tag);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id ==null)
            {
                return NotFound();
            }
            var tag= _context.Tags.Find(id);
                
            return View(tag);
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Tag tag)
        {
            try
            {
                var editedTag = _context.Tags.Find(id);
                editedTag.Name = tag.Name;
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
                if (id ==null)
                {
                    return NotFound();
                }
                var deletedTag=_context.Tags.Find(id);
                if (deletedTag is null)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Data is not available"
                    });
                }
                _context.Remove(deletedTag);
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

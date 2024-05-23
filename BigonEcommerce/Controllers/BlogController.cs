using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

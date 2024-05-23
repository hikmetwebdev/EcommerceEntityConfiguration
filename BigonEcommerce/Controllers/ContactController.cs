using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

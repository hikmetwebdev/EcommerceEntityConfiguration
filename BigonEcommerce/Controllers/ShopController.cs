using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

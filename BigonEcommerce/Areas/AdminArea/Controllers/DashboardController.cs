using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

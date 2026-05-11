using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

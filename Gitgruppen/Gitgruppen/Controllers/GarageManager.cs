using Microsoft.AspNetCore.Mvc;

namespace Gitgruppen.Controllers
{
    public class GarageManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

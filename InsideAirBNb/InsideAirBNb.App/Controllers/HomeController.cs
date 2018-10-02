using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace InsideAirBNB.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() {}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

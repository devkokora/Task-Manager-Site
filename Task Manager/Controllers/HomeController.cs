using Microsoft.AspNetCore.Mvc;

namespace Task_Manager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.test = "Chukkadig";
            return View(ViewBag);
        }
    }
}

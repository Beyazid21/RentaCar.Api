using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.V1 = "Haqqımızda";
            ViewBag.V2 = "Haqqımızda";
          
            return View();
        }
    }
}

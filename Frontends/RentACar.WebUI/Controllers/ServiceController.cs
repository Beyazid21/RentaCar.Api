using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.AboutDtos;
using RentACar.Dto.ServiceDtos;

namespace RentACar.WebUI.Controllers
{
    public class ServiceController : Controller
    {
      

        public  IActionResult Index()
        {
            ViewBag.V1 = "Xidmətlər";
            ViewBag.V2 = "Xidmətlərimiz";
            return View();
        }
    }
}

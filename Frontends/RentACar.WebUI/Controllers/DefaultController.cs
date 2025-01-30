using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentACar.Dto.LocationDtos;

namespace RentACar.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7254/api/Locations/LocationList");
         
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> values2=(from x in values select  new SelectListItem
                {
                    Text=x.Name,
                    Value=x.LocationId.ToString(),
                } ).ToList();

            ViewBag.V = values2;
            return View();

        
        }
        [HttpPost]

        public IActionResult Index(string pickupdate,string takeoffdate,string pickuptime,string takeofftime,string locationId)
        {
            TempData["pickupdate"]=pickupdate;
            TempData["takeoffdate"] = takeoffdate;
            TempData["pickuptime"] = pickuptime;
            TempData["takeofftime"] = takeofftime;
            TempData["locationId"] = locationId;

            return RedirectToAction("Index", "RentACarList");

            
        }
    }
}

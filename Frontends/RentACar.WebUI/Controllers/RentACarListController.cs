using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.BrandDtos;
using RentACar.Dto.RentACarDtos;
using System.Net.Http;
using System.Text;

namespace RentACar.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            var pickupdate = TempData["pickupdate"];

          var takeoffdate= TempData["takeoffdate"];
          var pickuptime =  TempData["pickuptime"];
          var takeofftime=  TempData["takeofftime"];
          var locationId = TempData["locationId"];
        id = Convert.ToInt32(locationId);


            ViewBag.pickupdate= pickupdate;
            ViewBag.takeoffdate = takeoffdate;
            ViewBag.pickuptime = pickuptime;
            ViewBag.takeofftime = takeofftime;
            ViewBag.locationId = locationId;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7254/api/RentACars/GetRentACarListByLocation?locationId={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);

            }
            return View();



        }
    }
}

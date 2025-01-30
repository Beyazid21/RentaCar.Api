using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.CarDtos;
using RentACar.Dto.CarPricingDtos;
using RentACar.Dto.ServiceDtos;

namespace RentACar.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.V1 = "Avtomobillər";
            ViewBag.V2 = "Zövqünüzə uyqun ən son model avtomobillərimiz";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/CarPricings/GetCarPricingWithCarList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();//jsondaki melumati string kimi oxuyur
                var values = JsonConvert.DeserializeObject<List<ResultCarWithPricingDto>>(jsondata);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.V1 = "Avtomobillər";
            ViewBag.V2 = "Seçilmiş Avtomobil Haqqında daha çox məlumat əldə edin...";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/CarSingle/CarDetail/+{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();//jsondaki melumati string kimi oxuyur
                var values = JsonConvert.DeserializeObject<ResultCarDetailDto>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}

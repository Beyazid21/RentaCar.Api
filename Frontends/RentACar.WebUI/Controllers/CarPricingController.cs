using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.CarPricingDtos;

namespace RentACar.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
        {
            ViewBag.V1 = "Paketlər";
            ViewBag.V2 = "Avtomobil qiymət paketləri";
            var client=_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7254/api/CarPricings/GetCarPricingWithTimePeriod");

            if (responseMessage.IsSuccessStatusCode)
            {
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCarPricingWithTimePeriod>>(jsondata);

                return View(values);

			}



			return View();
        }
    }
}

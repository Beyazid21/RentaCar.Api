using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.StatisticsDtos;
using System.Net.Http;

namespace RentACar.WebUI.ViewComponents.DeaultViewComponent
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()

        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.CarCount = values.carCount;

            }

            var responseMessage1 = await client.GetAsync("https://localhost:7254/api/Statistics/GetLocationCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.LocationCount = values.locationCount;

            }

            var responseMessage4 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBrandCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.BrandCount = values.brandCount;

            }

            var responseMessage13 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage13.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.CarCountByFuelElectric = values.carCount;

            }
            return View();
        }
    }
}

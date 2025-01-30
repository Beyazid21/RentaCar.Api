using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.AuthorDtos;
using RentACar.Dto.StatisticsDtos;

namespace RentACar.WebUI.Areas.Admin.Controllers
{

    [Route("Admin/[controller]/[action]")]
    [Area(nameof(Admin))]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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

            var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAuthorCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.AuthorCount = values.authorCount;

            }

            var responseMessage3 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.AuthorCount = values.authorCount;

            }

            var responseMessage4 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBrandCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.BrandCount = values.brandCount;

            }

            var responseMessage5 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBlogCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.BlogCount = values.blogCount;

            }

            var responseMessage6 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAvgRentPriceCarForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage6.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.AvgDailyPrice = values.price;

            }

            var responseMessage7 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAvgRentPriceCarForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage7.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.AvgWeeklyPrice = values.price;

            }

            var responseMessage8 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAvgRentPriceCarForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage8.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.AvgMonthlyPrice = values.price;

            }

            var responseMessage9 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage9.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.CountAutoCar = values.carCount;

            }

            var responseMessage10 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage10.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.MaxCarBrandName = values.brandName;

            }

            var responseMessage11 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByKmSmallerThan1000");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage11.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.CarCountByKmSmallerThan1000 = values.carCount;

            }

            var responseMessage12 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByFuelGasolineorDiesel");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage12.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.CarCountByFuelGasolineorDiesel = values.carCount;

            }
            var responseMessage13 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage13.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.CarCountByFuelElectric = values.carCount;

            }

            var responseMessage14 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage14.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.CarBrandAndModelByRentPriceDailyMax = values.name;

            }

            var responseMessage15 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage15.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<StatisticsDto>(jsonData);
                ViewBag.CarBrandAndModelByRentPriceDailyMin = values.name;

            }
            return View();


        }
    }
}

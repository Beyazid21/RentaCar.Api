using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.BannerDtos;
using RentACar.Dto.CarFeatureDto;
using RentACar.Dto.CarFeatureDtos;
using RentACar.Dto.FeatureDtos;
using System.Text;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Route("Admin/[controller]/[action]")]
    public class AdminCarFeatureDetailController : Controller
    {


    
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7254/api/CarFeatures/CarFeatureListByCarId/+{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureDto> dtos)
        {
            ChangeAvaliableToTrueDto trueDto = new ChangeAvaliableToTrueDto { CarFeatureIds = new List<int>() };
            ChangeAvaliableToFalseDto falseDto = new ChangeAvaliableToFalseDto { CarFeatureIds = new List<int>() };

            foreach (var d in dtos)
            {
                if (d.Available)
                {
                    trueDto.CarFeatureIds.Add(d.CarFeatureId);
                }
                else
                {
                    falseDto.CarFeatureIds.Add(d.CarFeatureId);
                }
            }

            var client = _httpClientFactory.CreateClient();

            // TrueDto üçün sorğu yalnız boş deyilsə göndərilir
            if (trueDto.CarFeatureIds.Any())
            {
                var jsonDataForTrue = JsonConvert.SerializeObject(trueDto);
                StringContent stringContentForTrue = new StringContent(jsonDataForTrue, Encoding.UTF8, "application/json");
                var responseMessageForTrue = await client.PutAsync("https://localhost:7254/api/CarFeatures/UpdateAvailableToTrue", stringContentForTrue);

                if (!responseMessageForTrue.IsSuccessStatusCode)
                {
                    return View(); // Əgər sorğu uğursuz olarsa səhifəyə geri dön
                }
            }

            // FalseDto üçün sorğu yalnız boş deyilsə göndərilir
            if (falseDto.CarFeatureIds.Any())
            {
                var jsonDataForFalse = JsonConvert.SerializeObject(falseDto);
                StringContent stringContentForFalse = new StringContent(jsonDataForFalse, Encoding.UTF8, "application/json");
                var responseMessageForFalse = await client.PutAsync("https://localhost:7254/api/CarFeatures/UpdateAvailableToFalse", stringContentForFalse);

                if (!responseMessageForFalse.IsSuccessStatusCode)
                {
                    return View(); // Əgər sorğu uğursuz olarsa səhifəyə geri dön
                }
            }

            // Əgər hər iki sorğu uğurlu olarsa
            return RedirectToAction("Index", "AdminCar");
        }


        public async Task<IActionResult> CreatrFeatureByCarId(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Features/FeatureList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);

            }
            return View();
        }

    }
}

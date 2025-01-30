using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.LocationDtos;
using System.Text;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]")]
    [Area(nameof(Admin))]
    public class AdminLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7254/api/Locations/LocationList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        public IActionResult CreateLocation()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocation)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLocation);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7254/api/Locations/CreateLocation", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
        [Route("{id}")]

        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Locations/GetLocation/+{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        [Route("{id}")]

        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocation)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocation);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7254/api/Locations/UpdateLocation", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }

            return View();

        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Locations/RemoveLocation/+{id}");

            return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });



        }
    }
}

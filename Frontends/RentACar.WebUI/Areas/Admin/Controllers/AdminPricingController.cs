using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.PricingDtos;
using System.Text;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]")]
    [Area(nameof(Admin))]
    public class AdminPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7254/api/Pricings/PricingList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        public IActionResult CreatePricing()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricing)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPricing);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7254/api/Pricings/CreatePricing", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
            return View();
        }
        [Route("{id}")]

        public async Task<IActionResult> UpdatePricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Pricings/GetPricing/+{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        [Route("{id}")]

        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricing)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePricing);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7254/api/Pricings/UpdatePricing", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }

            return View();

        }

        public async Task<IActionResult> DeletePricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Pricings/RemovePricing/+{id}");

            return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });



        }
    }
}

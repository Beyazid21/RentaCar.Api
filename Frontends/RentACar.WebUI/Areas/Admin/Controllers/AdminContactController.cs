using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.ContactDtos;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]")]
    [Area(nameof(Admin))]
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7254/api/Contacts/ContactList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}

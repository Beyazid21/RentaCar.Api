using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentACar.Dto.LocationDtos;
using RentACar.Dto.ReservationDtos;
using RentACar.Dto.TestimonialDtos;
using System.Text;

namespace RentACar.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int carid)
        {
            ViewBag.CarId = carid;
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7254/api/Locations/LocationList");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.LocationId.ToString(),
                                            }).ToList();
            ViewBag.V = values2;
            ViewBag.V1 = "Avtomobil kiralama";
            ViewBag.V2 = "Avtomobil kiralama formu";
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createreservation,int carid)
        {
            ViewBag.CarId = carid;
            var client = _httpClientFactory.CreateClient();

            // DropDown üçün lazımi dəyərləri yenidən yükləyirik
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Locations/LocationList");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.LocationId.ToString(),
                                            }).ToList();
            ViewBag.V = values2;

            // Rezervasiya məlumatını POST edirik
            var jsonDataPost = JsonConvert.SerializeObject(createreservation);
            StringContent stringContent = new StringContent(jsonDataPost, Encoding.UTF8, "application/json");
            var responsePost = await client.PostAsync("https://localhost:7254/api/Reservations/CreateReservation", stringContent);

            if (responsePost.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Əməliyyat uğurlu oldu, xahiş olunur email ünvanınızı yoxlayın.";
                return RedirectToAction("Index", "Default");
            }

            TempData["ErrorMessage"] = "Əməliyyat zamanı xəta baş verdi, xahiş olunur bir daha cəhd edin.";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentACar.Dto.BrandDtos;
using RentACar.Dto.CarDtos;
using System.Text;

namespace RentACar.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Cars/CarListWithBrand");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        public async  Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Brands/BrandList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
               List<SelectListItem> brandvalues= (from x in values 
                                                  select new SelectListItem
                                                  {
                                                      Text=x.Model,
                                                      Value=x.BrandId.ToString()
                                                   } ).ToList();
                ViewBag.BrandValues = brandvalues;
           
                return View();
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateCar(CreateCarDto createCar)
        {
         
                        var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCar);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7254/api/Cars/CreateCar",stringcontent);
            if (responseMessage.IsSuccessStatusCode) 
            { 
            
            return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Cars/RemoveCar/+{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
             return View();

        }


        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7254/api/Brands/BrandList");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
                List<SelectListItem> brandvalues = (from x in values1
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Model,
                                                        Value = x.BrandId.ToString()
                                                    }).ToList();
                ViewBag.BrandValues = brandvalues;

            

            }
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Cars/GetCar/+{id}");

            if (responseMessage.IsSuccessStatusCode) 
            { 
            var jsonData =await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCar)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCar);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7254/api/Cars/UpdateCar/", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

        

       
    }

  



   
}



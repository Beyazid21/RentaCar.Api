using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.FeatureDtos;
using System.Text;

namespace RentACar.WebUI.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly  IHttpClientFactory _httpClientFactory;

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7254/api/Features/FeatureList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
                
            }
            return View();
        }

        public IActionResult CreateFeature()
        {

            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeature)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createFeature);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7254/api/Features/CreateFeature", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");   
            }
            return View();
        }

        public async Task<IActionResult> UpdateFeature(int id )
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Features/GetFeature/+{id}");
            if (responseMessage.IsSuccessStatusCode)
            { 
            var jsonData= await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(values);
            
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeature)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(updateFeature);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7254/api/Features/UpdateFeature",stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            { 
            return RedirectToAction("Index");  
            }

            return View();

        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Features/RemoveFeature/+{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}

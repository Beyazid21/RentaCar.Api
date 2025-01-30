using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.AboutDtos;
using System.Net.Http;

namespace RentACar.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Abouts/AboutList");

            if (responseMessage.IsSuccessStatusCode) //yeni api geri donusu 200 durse
            { 
              
               var jsondata= await responseMessage.Content.ReadAsStringAsync();//jsondaki melumati string kimi oxuyur
               var values=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.ServiceDtos;
using System.Net.Http;

namespace RentACar.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceViewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Services/ServiceList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();//jsondaki melumati string kimi oxuyur
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.CategoryDtos;
using RentACar.Dto.ServiceDtos;

namespace RentACar.WebUI.ViewComponents.BlogViewComponent
{
    public class _BlogDetailCategoryComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/CategoriesCantroller/CategoryList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();//jsondaki melumati string kimi oxuyur
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}

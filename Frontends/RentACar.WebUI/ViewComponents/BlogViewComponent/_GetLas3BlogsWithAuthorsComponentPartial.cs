using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.BlogDtos;

namespace RentACar.WebUI.ViewComponents.BlogViewComponent
{
    public class _GetLas3BlogsWithAuthorsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetLas3BlogsWithAuthorsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage =await client.GetAsync("https://localhost:7254/api/Blogs/Lat3BlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode) 
            { 
            
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var value=JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthorsDto>>(jsonData);

                return  View(value);
            
            }
            return View();
        }
    }
}

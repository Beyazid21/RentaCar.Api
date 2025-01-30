using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.BlogDtos;
using RentACar.Dto.TagCloudDto;

namespace RentACar.WebUI.ViewComponents.BlogViewComponent
{
    public class _BlogDetailCloudTagByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCloudTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/TagClouds/TagCloudListByBlogId/+{id}");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTagCloudByBlogIdDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}


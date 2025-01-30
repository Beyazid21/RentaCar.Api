using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.AboutDtos;
using RentACar.Dto.BlogDtos;

namespace RentACar.WebUI.ViewComponents.BlogViewComponent
{
    public class _BlogDetailtMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailtMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync($"https://localhost:7254/api/Comments/CommentCountByBlogId/+{id}");

            if (responseMessage1.IsSuccessStatusCode)
            {

                var jsondata = await responseMessage1.Content.ReadAsStringAsync();
                var countcomment = JsonConvert.DeserializeObject<Count>(jsondata);
                ViewBag.CommentCount = countcomment.count;

            }
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Blogs/GetBlog/+{id}");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBlogByIdDto>(jsondata);
                return View(values);
            }

           
            return View();
        }



    }
    public class Count{

        public int count { get; set; }
    }
}

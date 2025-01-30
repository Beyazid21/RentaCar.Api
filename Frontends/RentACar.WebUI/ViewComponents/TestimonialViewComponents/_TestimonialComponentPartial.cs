using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Versioning;
using RentACar.Dto.TestimonialDtos;

namespace RentACar.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Testimonials/TestimonialList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata);

                return View(values);
            }
            return View();
        }
    }
}

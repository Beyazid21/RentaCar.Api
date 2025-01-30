using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.FooterAddressDtos;
using RentACar.Dto.TestimonialDtos;

namespace RentACar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterUILayoutViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/FooterAddresss/FooterAddressList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsondata);

                return View(values);
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Testimonial>>(jsonData);
                return values;
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryServices;

        public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoryServices)
        {
            _httpClientFactory = httpClientFactory;
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
        {
            string token = "";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"), //bir apiden jwt token alır ve bu tokenı kullanarak başka apiye yetkilendirilmiş istek yapar
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id","MultiShopVisitorId" },
                        {"client_secret","multishopsecret" },
                        {"grant_type","client_credentials" }
                    })
                };

                using (var response = await httpClient.SendAsync(request)) //token alma başarılıysa yanıtın içeriği ayrıştırılır ve token alınır..
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);
                        token = tokenResponse["access_token"].ToString();
                    }
                }
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);



            var responseMessage = await client.GetAsync("http://localhost:7071/api/Categories"); //yapılan token ile artık burası gözükmeliii
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<DtoLayer.CatalogDtos.CategoryDtos.ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult Deneme1()
        {
            return View();
        }


        public async Task<IActionResult> Deneme2()
        {
            var values=await _categoryServices.GetAllCategoryAsync();
            return View(values);
        }

    }
}
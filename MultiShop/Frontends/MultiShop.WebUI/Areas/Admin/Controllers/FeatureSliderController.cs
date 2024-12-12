using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IHttpClientFactory httpClientFactory, IFeatureSliderService featureSliderService)
        {
            _httpClientFactory = httpClientFactory;
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Slider Öne Çıkan Görsel Listesi";
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";

            //var client = _httpClientFactory.CreateClient();
            //var responseMessagE = await client.GetAsync("https://localhost:7071/api/FeatureSliders");
            //if (responseMessagE.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessagE.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
            //    return View(values);
            //}
            //return View();

            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            if (values.IsNullOrEmpty())
            {
                return View();
            }
            return View(values);
        }





        [Route("CreateFeatureSlider")]
        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Slider Öne Çıkan Görsel Ekleme";
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
            return View();
        }

        [Route("CreateFeatureSlider")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = true;
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7071/api/FeatureSliders", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();

            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }



        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"https://localhost:7071/api/FeatureSliders/?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();

            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }



        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Slider Öne Çıkan Görsel Güncelleme";
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:7071/api/FeatureSliders/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
            //    return View(values);
            //}
            //return View();

            var values=await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);

        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:7071/api/FeatureSliders", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();

            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}

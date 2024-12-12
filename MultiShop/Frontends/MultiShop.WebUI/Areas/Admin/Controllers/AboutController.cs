using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAboutService _aboutService;

        public AboutController(IHttpClientFactory httpClientFactory, IAboutService aboutService)
        {
            _httpClientFactory = httpClientFactory;
            _aboutService = aboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Listesi";
            ViewBag.v0 = "Hakkımızda İşlemleri";

            //var client = _httpClientFactory.CreateClient();
            //var responseMessagE = await client.GetAsync("https://localhost:7071/api/Abouts");
            //if (responseMessagE.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessagE.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            //    return View(values);
            //}
            //return View();

            var values = await _aboutService.GetAllAboutAsync();
            if (values.IsNullOrEmpty())
            {
                return View();
            }
            return View(values);
        }




        [Route("CreateAbout")]
        [HttpGet]
        public IActionResult CreateAbout()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Ekle";
            ViewBag.v0 = "Hakkımızda İşlemleri";
            return View();
        }

        [Route("CreateAbout")]
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createAboutDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7071/api/Abouts", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "About", new { area = "Admin" });
            //}
            //return View();

            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }



        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"https://localhost:7071/api/Abouts/?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "About", new { area = "Admin" });
            //}
            //return View();

            await _aboutService.DeleteAboutAsync    (id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }



        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Güncelle";
            ViewBag.v0 = "Hakkımızda İşlemleri";
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:7071/api/Abouts/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
            //    return View(values);
            //}
            //return View();

           var values=await _aboutService.GetByIdAboutAsync(id);
            return View(values);

        }

        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateAboutDto updateAboutDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:7071/api/Abouts", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "About", new { area = "Admin" });
            //}
            //return View();

            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}

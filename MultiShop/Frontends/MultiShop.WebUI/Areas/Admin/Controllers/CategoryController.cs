using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Core.WireProtocol.Messages;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;

        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }





        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.v0 = "Kategori İşlemleri";


            //// bu şu an çalışmaz çünkü token yok bunda

            //var client=_httpClientFactory.CreateClient();
            //var responseMessagE = await client.GetAsync("http://localhost:7071/api/Categories");
            //if(responseMessagE.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessagE.Content.ReadAsStringAsync();
            //    var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            //    return View(values);
            //}
            //return View();

            var values = await _categoryService.GetAllCategoryAsync();
            if (values.IsNullOrEmpty())
            {
                return View();
            }
            return View(values);
        }




        [Route("CreateCategory")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            ViewBag.v0 = "Kategori İşlemleri";
            return View();
        }

        [Route("CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            //StringContent stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7071/api/Categories", stringContent);
            //if(responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index","Category",new {area="Admin"});
            //}
            //return View();

            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }



        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"https://localhost:7071/api/Categories/?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Category", new { area = "Admin" });
            //}
            //return View();


            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }



        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Güncelleme Sayfası";
            ViewBag.v0 = "Kategori İşlemleri";
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:7071/api/Categories/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
            //    return View(values);
            //}
            //return View();

            var value=await _categoryService.GetByIdCategoryAsync(id);
            return View(value);

        }

        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:7071/api/Categories", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Category", new { area = "Admin" });
            //}
            //return View();

            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;


namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _CategoriesDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;

        public _CategoriesDefaultComponentPartial(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessagE = await client.GetAsync("https://localhost:7071/api/Categories");
            //if (responseMessagE.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessagE.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            //    return View(values);
            //}
            //return View();


            var values=await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}

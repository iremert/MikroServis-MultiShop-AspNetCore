using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;

        public _ProductDetailFeatureComponentPartial(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var client2 = _httpClientFactory.CreateClient();
            //var responseMessage2 = await client2.GetAsync($"https://localhost:7071/api/Products/{id}");
            //if (responseMessage2.IsSuccessStatusCode)
            //{
            //    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

            //    var values2 = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData2);
            //    return View(values2);
            //}
            //return View();

            var values = await _productService.GetByIdProductAsync(id);
            return View(values);
        }
    }
}

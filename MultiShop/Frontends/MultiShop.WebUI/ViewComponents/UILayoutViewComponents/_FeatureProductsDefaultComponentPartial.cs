using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FeatureProductsDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;

        public _FeatureProductsDefaultComponentPartial(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessagE = await client.GetAsync("https://localhost:7071/api/Products");
            //if (responseMessagE.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessagE.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            //    return View(values);
            //}
            //return View();

            var values=await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}

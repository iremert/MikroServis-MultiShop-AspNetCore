using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailInformationComponentPartial(IHttpClientFactory httpClientFactory, IProductDetailService productDetailService)
        {
            _httpClientFactory = httpClientFactory;
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var client2 = _httpClientFactory.CreateClient();
            //var responseMessage2 = await client2.GetAsync($"https://localhost:7071/api/ProductDetails/GetProductDetailByProductId?id={id}");

            //if (responseMessage2.IsSuccessStatusCode)
            //{
            //    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

            //    var values2 = JsonConvert.DeserializeObject<GetByIdProductDetailDto>(jsonData2);
            //    return View(values2);

            //}
            //return View();

            var value=await _productDetailService.GetByProductDetailWithByProductIdAsync(id);
            return View(value);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _VendorDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBrandService _brandService;

        public _VendorDefaultComponentPartial(IHttpClientFactory httpClientFactory, IBrandService brandService)
        {
            _httpClientFactory = httpClientFactory;
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessagE = await client.GetAsync("https://localhost:7071/api/Brands");
            //if (responseMessagE.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessagE.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            //    return View(values);
            //}
            //return View();


            var values=await _brandService.GetAllBrandAsync();
            return View(values);
        }
    }
}

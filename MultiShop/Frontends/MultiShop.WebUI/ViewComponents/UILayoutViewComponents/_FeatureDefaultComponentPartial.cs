

using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FeatureDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureService _featureService;

        public _FeatureDefaultComponentPartial(IHttpClientFactory httpClientFactory, IFeatureService featureService)
        {
            _httpClientFactory = httpClientFactory;
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessagE = await client.GetAsync("https://localhost:7071/api/Features");
            //if (responseMessagE.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessagE.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            //    return View(values);
            //}
            //return View();

            var values=await _featureService.GetAllFeatureAsync();
            return View(values);    
        }
    }
}

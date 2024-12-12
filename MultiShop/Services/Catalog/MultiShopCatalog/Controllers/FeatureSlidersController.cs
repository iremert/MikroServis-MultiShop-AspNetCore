using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopCatalog.Dtos.CategoryDtos;
using MultiShopCatalog.Dtos.FeatureSliderDtos;
using MultiShopCatalog.Services.FeatureSliderServices;

namespace MultiShopCatalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderServices _featureSliderServices;

        public FeatureSlidersController(IFeatureSliderServices featureSliderServices)
        {
            _featureSliderServices = featureSliderServices;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderServices.GetAllFeatureSliderAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await _featureSliderServices.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            //normalde dto olmasa tek tek newleyip atamak yapmak gerekecekti...
            await _featureSliderServices.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Slider başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderServices.DeleteFeatureSliderAsync(id);
            return Ok("Slider başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderServices.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Slider başarıyla güncellendi");
        }
    }
}

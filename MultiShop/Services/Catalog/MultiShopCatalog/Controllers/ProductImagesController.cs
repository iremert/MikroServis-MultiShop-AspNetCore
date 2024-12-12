using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopCatalog.Dtos.ProductImageDtos;
using MultiShopCatalog.Services.ProductImageServices;

namespace MultiShopCatalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _ProductImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _ProductImageService.GetAllProductImageAsync();
            return Ok(values);
        }


        [HttpGet("ProductImagesByProductId/{id}")]
        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var values = await _ProductImageService.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values = await _ProductImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            //normalde dto olmasa tek tek newleyip atamak yapmak gerekecekti...
            await _ProductImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün resmi başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _ProductImageService.DeleteProductImageAsync(id);
            return Ok("Ürün resmi başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün resmi başarıyla güncellendi");
        }
    }
}

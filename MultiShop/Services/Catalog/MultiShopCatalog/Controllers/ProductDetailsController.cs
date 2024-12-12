using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopCatalog.Dtos.ProductDetailDtos;
using MultiShopCatalog.Services.ProductDetailServices;

namespace MultiShopCatalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _ProductDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _ProductDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values =await _ProductDetailService.GetByIDProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            //normalde dto olmasa tek tek newleyip atamak yapmak gerekecekti...
            await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayları başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _ProductDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayları başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayları başarıyla güncellendi");
        }


        [HttpGet("GetProductDetailByProductId/{id}")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var values=await _ProductDetailService.GetByProductDetailWithByProductIdAsync(id);
            return Ok(values);
        }
    }
}

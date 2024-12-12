using MultiShopCatalog.Dtos.ProductDetailDtos;

namespace MultiShopCatalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIDProductDetailDto> GetByIDProductDetailAsync(string id);
        Task<GetByIDProductDetailDto> GetByProductDetailWithByProductIdAsync(string id);
    }
}

using MultiShopCatalog.Dtos.FeatureSliderDtos;

namespace MultiShopCatalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderServices
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSlider> GetByIdFeatureSliderAsync(string id);
    }
}

﻿using MultiShopCatalog.Dtos.CategoryDtos;

namespace MultiShopCatalog.Services.CategoryServices
{
    public interface ICategoryServices
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}

using AutoMapper;
using MongoDB.Driver;
using MultiShopCatalog.Dtos.ProductDtos;
using MultiShopCatalog.Entities;
using MultiShopCatalog.Settings;

namespace MultiShopCatalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client=new MongoClient(databaseSettings.ConnectionString);  
            var dataBase=client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = dataBase.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection=dataBase.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values=_mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);    
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductId==id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values); 
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach(var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);

        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryId==CategoryId).ToListAsync();
            foreach(var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.CategoryId==updateProductDto.CategoryId,value);
        }
    }
}

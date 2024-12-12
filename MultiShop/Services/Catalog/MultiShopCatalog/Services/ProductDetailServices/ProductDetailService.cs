using AutoMapper;
using MongoDB.Driver;
using MultiShopCatalog.Dtos.ProductDetailDtos;
using MultiShopCatalog.Entities;
using MultiShopCatalog.Settings;

namespace MultiShopCatalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productCollection;

        public ProductDetailService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values=_mapper.Map<ProductDetail>(createProductDetailDto);  
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductDetailID==id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values =await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);   
        }

        public async Task<GetByIDProductDetailDto> GetByIDProductDetailAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDProductDetailDto>(value);
        }

        public async Task<GetByIDProductDetailDto> GetByProductDetailWithByProductIdAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productCollection.FindOneAndReplaceAsync<ProductDetail>(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, value);
        }
    }
}

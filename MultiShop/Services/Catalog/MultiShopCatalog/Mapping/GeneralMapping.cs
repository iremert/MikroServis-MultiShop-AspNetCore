using AutoMapper;
using MongoDB.Driver.Core.Misc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShopCatalog.Dtos.AboutDtos;
using MultiShopCatalog.Dtos.BrandDtos;
using MultiShopCatalog.Dtos.CategoryDtos;
using MultiShopCatalog.Dtos.FeatureSliderDtos;
using MultiShopCatalog.Dtos.OfferDiscountDtos;
using MultiShopCatalog.Dtos.ProductDetailDtos;
using MultiShopCatalog.Dtos.ProductDtos;
using MultiShopCatalog.Dtos.ProductImageDtos;
using MultiShopCatalog.Dtos.SpecialOfferDtos;
using MultiShopCatalog.Entities;

namespace MultiShopCatalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            //new lemek yerine eşleştiriyoz..
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIDProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

            CreateMap<Product,ResultProductsWithCategoryDto>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSlider>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();


            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();

            CreateMap<Entities.Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Entities.Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Entities.Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Entities.Feature, UpdateFeatureDto>().ReverseMap();

            CreateMap<Entities.OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<Entities.OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();
            CreateMap<Entities.OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<Entities.OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();

            CreateMap<Entities.Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Entities.Brand, GetByIdBrandDto>().ReverseMap();
            CreateMap<Entities.Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Entities.Brand, UpdateBrandDto>().ReverseMap();

            CreateMap<Entities.About, ResultAboutDto>().ReverseMap();
            CreateMap<Entities.About, GetByIdAboutDto>().ReverseMap();
            CreateMap<Entities.About, CreateAboutDto>().ReverseMap();
            CreateMap<Entities.About, UpdateAboutDto>().ReverseMap();

            CreateMap<Entities.Contact, ResultContactDto>().ReverseMap();
            CreateMap<Entities.Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Entities.Contact, CreateContactDto>().ReverseMap();
            CreateMap<Entities.Contact, UpdateContactDto>().ReverseMap();

        }
    }
}

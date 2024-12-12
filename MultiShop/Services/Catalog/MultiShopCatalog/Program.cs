//REGÝSTRATÝON ZAMANI




using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.ContactServices;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShopCatalog.Services.AboutServices;
using MultiShopCatalog.Services.BrandServices;
using MultiShopCatalog.Services.CategoryServices;
using MultiShopCatalog.Services.FeatureSliderServices;
using MultiShopCatalog.Services.OfferDiscountServices;
using MultiShopCatalog.Services.ProductDetailServices;
using MultiShopCatalog.Services.ProductImageServices;
using MultiShopCatalog.Services.ProductServices;
using MultiShopCatalog.Services.SpecialOfferServices;
using MultiShopCatalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



//tokenýn geçerliliðini kontrol edicez

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    //appsettingse identity server localhostunu ekledik bu sayede çalýþýnca catalog artýk o da çalýþçak
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    //config tarafýnda dinleyici olan key yani bu keyi alýyoruz bu sayede onun kýsýtlamalrýný alýr sadece onlara ulaþýr.
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});



builder.Services.AddScoped<ICategoryServices, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderServices, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //üst sürümlerde hata alýnýyor böyle

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});






// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShopDiscount.Context;
using MultiShopDiscount.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    //appsettingse identity server localhostunu ekledik bu sayede çalýþýnca catalog artýk o da çalýþçak
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    //config tarafýnda dinleyici olan key yani bu keyi alýyoruz bu sayede onun kýsýtlamalrýný alýr sadece onlara ulaþýr.
    opt.Audience = "ResourceDiscount";
    opt.RequireHttpsMetadata = false;
});




builder.Services.AddTransient<DapperContext>();
builder.Services.AddTransient<IDiscountService,DiscountService>();







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

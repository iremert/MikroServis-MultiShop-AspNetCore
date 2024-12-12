﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code, int discountRate,decimal totalPriceWithDiscount)
        {
            //ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalPriceWithDiscount = totalPriceWithDiscount;

            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";


            var values =await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;

            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            ViewBag.tax = values.TotalPrice / 100 * 10;
            ViewBag.totalPriceWithTax=totalPriceWithTax;    

            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl=values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItems(id);
            return RedirectToAction("Index");
        }
    }
}
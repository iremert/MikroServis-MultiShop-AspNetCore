﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDiscountCoupon()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            //var values = _discountService.GetDiscountCode(code);
            var values = await _discountService.GetDiscountCouponCountRate(code);

            var basketValues = await _basketService.GetBasket();
            ViewBag.total = basketValues.TotalPrice;

            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 10;
            var totalPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);
            
            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate=values , totalPriceWithDiscount = totalPriceWithDiscount });


            //var values=_discountService.GetDiscountCode(code);
           
        }
    }
}

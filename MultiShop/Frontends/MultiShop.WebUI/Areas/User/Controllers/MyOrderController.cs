using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderOrderingService orderOrderingService, IUserService userService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            //var user=await _userService.GetUserInfo();
            var userId = "57fddfcd-4cc3-44d9-bf0b-a9b0a7e5b4f1";
            var values = await _orderOrderingService.GetOrderingByUserId(userId);
            return View(values);
        }
    }
}

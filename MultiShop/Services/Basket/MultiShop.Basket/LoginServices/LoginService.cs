using System.Security.Claims;

namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        //public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        public string GetUserId => "57fddfcd-4cc3-44d9-bf0b-a9b0a7e5b4f1";
    }
}

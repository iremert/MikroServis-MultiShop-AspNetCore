using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
	    {

            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createLoginDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("http://localhost:5001/api/Logins", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonDataa = await responseMessage.Content.ReadAsStringAsync();
            //    var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(jsonDataa, new JsonSerializerOptions
            //    {
            //        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //    });

            //    if (tokenModel != null)
            //    {
            //        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            //        var token = handler.ReadJwtToken(tokenModel.Token);
            //        var claims = token.Claims.ToList();

            //        if (tokenModel.Token != null)
            //        {
            //            claims.Add(new System.Security.Claims.Claim("multishoptoken", tokenModel.Token));
            //            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            //            var authProps = new AuthenticationProperties
            //            {
            //                ExpiresUtc = tokenModel.ExpireDate,
            //                IsPersistent = true
            //            };

            //            await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
            //            var id = _loginService.GetUserId;
            //            return RedirectToAction("Index", "User");
            //        }
            //    }
            //}

            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "User");
         
        }



        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    return View();
        //}

        ////[HttpPost]
        //public async Task<IActionResult> SignIn(SignInDto signInDto)
        //{
        //    signInDto.Username = "ali01";
        //    signInDto.Password = "123456aA*";
        //    var durum = await _identityService.SignIn(signInDto);
        //    //return RedirectToAction("Index", "Test");
        //    return RedirectToAction("Index", "User");
        //}
    }
}

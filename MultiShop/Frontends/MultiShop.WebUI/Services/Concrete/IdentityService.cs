using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient; //http istekleri yapmak için 
        private readonly IHttpContextAccessor _contextAccessor; //http bağlamına erişmek için
        private readonly ClientSettings _clientSettings; //müşteri ayarları
        private readonly ServiceApiSettings _serviceApiSettings; //servis api ayarları

        public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            });



            var refreshToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken); //mevcut oturumdan refresh tokenı alır..
            RefreshTokenRequest refreshTokenRequest = new()
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                RefreshToken=refreshToken,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest); //refresh token kullanarak yeni erişim tokenı isteğinde bulunur.
            var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken //yeni erişim tokenı
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value=token.AccessToken
                },
                new AuthenticationToken //yeni refresh token
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value=token.RefreshToken
                },
                new AuthenticationToken //erişim tokenı süresi
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            };

            var result = await _contextAccessor.HttpContext.AuthenticateAsync(); //mevcut kullanıcı oturumunu doğrular..
            var properties = result.Properties; //mevcut oturum özelliklerini alır
            properties.StoreTokens(authenticationToken); //yeni token bilgilerini oturum özelliklerine ekler...
            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,result.Principal,properties); //kullanıcıyı cookie tabanlı kimlik doğrualması ile oturum açar ve yeni token bilgilerini ekler..
            return true;
        }

        public async Task<bool> SignIn(SignInDto signInDto) 
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address=_serviceApiSettings.IdentityServerUrl,
                Policy=new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId=_clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret=_clientSettings.MultiShopManagerClient.ClientSecret,
                UserName=signInDto.Username,
                Password=signInDto.Password,
                Address=discoveryEndPoint.TokenEndpoint
            };

            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest); //token isteği
            var userInfoRequest = new UserInfoRequest
            {
                Token=token.AccessToken,
                Address=discoveryEndPoint.UserInfoEndpoint
            }; //alınan token ile kullanıcı bilgilerini almamk için istek oluşturur...

            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest); //kullanıcı bilgisi için istek...

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims,CookieAuthenticationDefaults.AuthenticationScheme,"name","role"); //kullanıcı bilgilerini içeren kimlik oluşturur...
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties(); //oturum açma özelliği ekler..
            authenticationProperties.StoreTokens(new List<AuthenticationToken>() //token bilgileirni oturum özelliklerine ekler...
            {
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value=token.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value=token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });
            authenticationProperties.IsPersistent = false;
            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties); //kullanıcıyı cookie tabanlı kimlik doğrulaması ile oturum açar..
            return true;


        }
    }
}

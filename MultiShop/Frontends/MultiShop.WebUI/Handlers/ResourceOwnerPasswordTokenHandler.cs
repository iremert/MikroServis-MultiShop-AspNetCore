
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler:DelegatingHandler  //http isteklerini yönetir
    {
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _contextAccessor; //http bağlamına erişmenizi ve kullanıcı tokenını almanızı sağlar...

        public ResourceOwnerPasswordTokenHandler(IIdentityService identityService, IHttpContextAccessor contextAccessor)
        {
            _identityService = identityService;
            _contextAccessor = contextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",accessToken);
            var response = await base.SendAsync(request, cancellationToken);
            if(response.StatusCode==System.Net.HttpStatusCode.Unauthorized) //403
            {
                var tokenResponse = await _identityService.GetRefreshToken(); //token üret
                if(tokenResponse!=null)
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }



            if(response.StatusCode== System.Net.HttpStatusCode.Unauthorized)
            {
                //hata mesajı
            }

            return response;
        }
    }
}

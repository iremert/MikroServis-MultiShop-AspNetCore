using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _settings;
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> settings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache,IOptions<ClientSettings> clientSettings)
        {
            _settings = settings.Value;
            _httpClient = httpClient;
            _clientAccessTokenCache = clientAccessTokenCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            var token1 = await _clientAccessTokenCache.GetAsync("multishoptoken");
            if(token1 != null)
            {
                return token1.AccessToken;
            }



            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _settings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            });


            var ClientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token2=await _httpClient.RequestClientCredentialsTokenAsync(ClientCredentialTokenRequest);
            await _clientAccessTokenCache.SetAsync("multishoptoken", token2.AccessToken, token2.ExpiresIn);
            return token2.AccessToken;    
        }
    }
}

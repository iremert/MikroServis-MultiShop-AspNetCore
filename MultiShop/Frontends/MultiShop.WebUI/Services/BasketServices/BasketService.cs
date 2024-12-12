using MultiShop.DtoLayer.BasketDtos;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketService(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if(values != null)
            {
                if(!values.BasketItems.Any(x=>x.ProductId==basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    values=new BasketTotalDto();
                  
                    values.BasketItems.Add(basketItemDto);
                }
            }
            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            //var responseMessage = await _httpClient.GetAsync("http://localhost:7074/api/Baskets"); //baskets
            var responseMessage = await _httpClient.GetAsync("baskets");    //baskets
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<BasketTotalDto>(jsonData);
            //return values;

            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;

        }
        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }

        public async Task<bool> RemoveBasketItems(string productId)
        {
            var values = await GetBasket();
            var deletedItem=values.BasketItems.FirstOrDefault(x=>x.ProductId==productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }
    }
}

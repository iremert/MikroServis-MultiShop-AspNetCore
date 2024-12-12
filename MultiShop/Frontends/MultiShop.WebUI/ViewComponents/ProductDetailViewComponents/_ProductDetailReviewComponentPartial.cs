using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var client2 = _httpClientFactory.CreateClient();
            //var responseMessage2 = await client2.GetAsync($"https://localhost:7014/api/Comments/CommentListByProductId/{id}");

            //if (responseMessage2.IsSuccessStatusCode)
            //{
            //    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

            //    var values2 = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData2);
            //    return View(values2);

            //}
            //return View();

            var values = await _commentService.CommentListByProductId(id);
            return View(values);

        }
    }
}

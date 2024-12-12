﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopComment.Context;

namespace MultiShopComment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticsController : ControllerBase
    {
        private readonly CommentContext _commentContext;
        public CommentStatisticsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentCount()
        {
            int values = await _commentContext.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
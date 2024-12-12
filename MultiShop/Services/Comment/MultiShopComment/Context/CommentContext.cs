using Microsoft.EntityFrameworkCore;
using MultiShopComment.Entities;
using System.Collections.Generic;

namespace MultiShopComment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=MultiShopCommentDb;User=sa;Password=123456aA*");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}

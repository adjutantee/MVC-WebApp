using Microsoft.EntityFrameworkCore;
using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;

namespace MVC_WebApp.db
{
    public class DataBaseContext : DbContext
    {
        // Доступ к таблицам. Каждый DbSet это доступ к какой то одной таблице.
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FavouriteProduct> FavoriteProducts { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Name1",
                    Description = "Кроссовки фирмы Nike",
                    ImagePath = "/css/PHTTest.png",
                    Cost = 15000
                },

                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Name2",
                    Description = "Кроссовки фирмы Nike",
                    ImagePath = "/css/PHTTest.png",
                    Cost = 11000
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Name3",
                    Description = "Кроссовки фирмы Nike",
                    ImagePath = "/css/PHTTest.png",
                    Cost = 17000
                },
            });

        }
    }
}

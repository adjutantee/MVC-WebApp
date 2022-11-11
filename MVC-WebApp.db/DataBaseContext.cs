using Microsoft.EntityFrameworkCore;
using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

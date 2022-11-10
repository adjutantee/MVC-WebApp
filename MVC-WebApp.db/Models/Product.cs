using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Cost { get; set; }
        public List<CartItem> CartItems { get; set; } 
    }
}

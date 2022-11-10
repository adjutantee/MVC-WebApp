﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.db.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }
        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo UserDeliveryInfo { get; set; }
        public List<CartItem> Items { get; set; }

        public OrderStatus Status { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Order()
        {
            Items = new List<CartItem>();
        }
    }
}

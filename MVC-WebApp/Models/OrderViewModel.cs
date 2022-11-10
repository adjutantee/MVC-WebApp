using OnlineWebApp_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public UserDeliveryInfoViewModel UserDeliveryInfo { get; set; }
        public List<CartItemViewModel> Items { get; set; }

        public OrderStatusViewModel Status { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public OrderViewModel()
        {
            Status = OrderStatusViewModel.Created;
        }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}

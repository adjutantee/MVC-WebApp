using MVC_WebApp.Models;
using OnlineWebApp_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        private List<Cart> orders = new List<Cart>();

        public void Add(Cart cart)
        {
            orders.Add(cart);
        }
    }
}

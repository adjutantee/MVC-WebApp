using MVC_WebApp.Models;
using OnlineWebApp_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return orders;
        }

        public Order TryGetByUserId(Guid id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStatus(Guid orderId, OrderStatus status)
        {
            var order = TryGetByUserId(orderId);

            if (order != null)
            {
                order.Status = status;
            }
        }
    }
}

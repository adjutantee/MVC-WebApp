using Microsoft.EntityFrameworkCore;
using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public OrdersDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public List<Order> GetAll()
        {
            return dataBaseContext.Orders.Include(x => x.UserDeliveryInfo).Include(x => x.Items).ThenInclude(x => x.Product).ToList();
        }

        public Order TryGetByUserId(Guid id)
        {
            return dataBaseContext.Orders.Include(x => x.UserDeliveryInfo).Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);
        }

        public void Add(List<CartItem> items, UserDeliveryInfo userDeliveryInfo)
        {
            var newOrder = new Order
            {
                Id = new Guid(),
                Items = items,
                UserDeliveryInfo = userDeliveryInfo,
                Date = DateTime.Now.ToString("dd MMMM yyyy"),
                Time = DateTime.Now.ToString("HH:mm:ss"),
            };
            dataBaseContext.Orders.Add(newOrder);
            dataBaseContext.SaveChanges();
        }

        public void UpdateStatus(Guid orderId, OrderStatus status)
        {
            var order = TryGetByUserId(orderId);

            if (order != null)
            {
                order.Status = status;
                dataBaseContext.SaveChanges();
            }
        }
    }
}

using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;

namespace MVC_WebApp.db
{
    public interface IOrdersRepository
    {
        void Add(List<CartItem> items, UserDeliveryInfo userDeliveryInfo);
        List<Order> GetAll();
        Order TryGetByUserId(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}
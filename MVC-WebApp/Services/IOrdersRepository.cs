using MVC_WebApp.Models;
using System;
using System.Collections.Generic;

namespace MVC_WebApp.Services
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetByUserId(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}
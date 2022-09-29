using MVC_WebApp.Models;

namespace MVC_WebApp.Services
{
    public interface IOrdersRepository
    {
        void Add(Cart cart);
    }
}
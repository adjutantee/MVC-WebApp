using MVC_WebApp.Models;
using OnlineWebApp_MVC.Models;

namespace MVC_WebApp.Services
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
    }
}
using MVC_WebApp.Models;
using OnlineWebApp_MVC.Models;
using System.Collections.Generic;

namespace OnlineWebApp_MVC.Services
{
    public interface IRolesRepository
    {
        List<Role> GetAllRole();
        Role TryGetByName(string Name);
        void Add(Role role);
        void Remove(string name);
    }
}
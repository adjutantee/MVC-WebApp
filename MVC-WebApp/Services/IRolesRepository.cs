using MVC_WebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineWebApp_MVC.Services
{
    public interface IRolesRepository
    {
        List<RoleViewModel> GetAllRole();
        RoleViewModel TryGetByName(string Name);
        void Add(RoleViewModel role);
        void Remove(string name);
    }
}
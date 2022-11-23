using MVC_WebApp.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineWebApp_MVC.Services
{
    public class RolesRepository : IRolesRepository
    {
        private readonly List<RoleViewModel> roles = new List<RoleViewModel>();
        public void Add(RoleViewModel role)
        {
            roles.Add(role);
        }

        public List<RoleViewModel> GetAllRole()
        {
            return roles;
        }

        public RoleViewModel TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
    }
}
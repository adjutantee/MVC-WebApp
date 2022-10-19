﻿using MVC_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineWebApp_MVC.Services
{
    public class RolesRepository : IRolesRepository
    {
        private readonly List<Role> roles = new List<Role>();

        public void Add(Role role)
        {
            roles.Add(role);
        }

        public List<Role> GetAllRole()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
    }
}
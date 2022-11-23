using MVC_WebApp.Models;
using System.Collections.Generic;

namespace MVC_WebApp.Services
{
    public interface IUserManager
    {
        void Add(UserViewModel user);
        void ChangePassword(string userName, string newPassword);
        List<UserViewModel> GetAllUsers();
        void Remove(string name);
        UserViewModel TryGetByName(string name);
        void UserEdit(UserViewModel user);
    }
}
using MVC_WebApp.Models;
using System.Collections.Generic;

namespace MVC_WebApp.Services
{
    public interface IUserManager
    {
        void Add(UserAccount user);
        void ChangePassword(string userName, string newPassword);
        List<UserAccount> GetAllUsers();
        UserAccount TryGetByName(string name);
        void UserEdit(UserAccount user);
    }
}
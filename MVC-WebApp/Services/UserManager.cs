using MVC_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.Services
{
    public class UserManager : IUserManager
    {
        private readonly List<UserViewModel> users = new List<UserViewModel>();

        public List<UserViewModel> GetAllUsers()
        {
            return users;
        }

        public void Add(UserViewModel user)
        {
            users.Add(user);
        }

        public UserViewModel TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
         }

        public void ChangePassword(string userName, string newPassword)
        {
            var account = TryGetByName(userName);
            account.Password = newPassword;
        }

        public void UserEdit(UserViewModel user)
        {
            var existingUser = TryGetByName(user.Name);
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.NumberPhone = user.NumberPhone;
        }

        public void Remove(string name)
        {
            users.Remove(TryGetByName(name));
        }
    }
}

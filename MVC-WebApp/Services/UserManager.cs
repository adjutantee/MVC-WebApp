using MVC_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.Services
{
    public class UserManager : IUserManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAllUsers()
        {
            return users;
        }

        public void Add(UserAccount user)
        {
            users.Add(user);
        }

        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
         }

        public void ChangePassword(string userName, string newPassword)
        {
            var account = TryGetByName(userName);
            account.Password = newPassword;
        }

        public void UserEdit(UserAccount user)
        {
            var existingUser = TryGetByName(user.Name);
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.NumberPhone = user.NumberPhone;
        }
    }
}

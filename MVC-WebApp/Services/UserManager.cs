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

        public UserAccount TryGetByName(string email)
        {
            return users.FirstOrDefault(x => x.Email == email);
        }

        public void ChangePassword(string userAccountName, string newPassword)
        {
            var userAccount = TryGetByName(userAccountName);
            userAccount.Password = newPassword;
        }
    }
}

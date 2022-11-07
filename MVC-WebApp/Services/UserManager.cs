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

        public void ChangePassword(string exampleLoginEmail, string newPassword)
        {
            var account = TryGetByName(exampleLoginEmail);
            account.Password = newPassword;
        }

        public void Edit(UserAccount user)
        {
            var existingUser = TryGetByName(user.Name);
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.NumberPhone = user.NumberPhone;
        }
    }
}

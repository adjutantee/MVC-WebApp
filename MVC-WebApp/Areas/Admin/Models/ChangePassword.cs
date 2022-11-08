using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Areas.Admin.Models
{
    public class ChangePassword
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Заполните поле пароля")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Заполните поле повторного ввода пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }


    }
}

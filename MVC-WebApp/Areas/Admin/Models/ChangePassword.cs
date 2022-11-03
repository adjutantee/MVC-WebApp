using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Areas.Admin.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Не указан emali")]
        public string UserAccountName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string UserAccountPassword { get; set; }
        [Required(ErrorMessage = "Поле повторного ввода пароля не указан")]
        [Compare("exampleLoginPassword", ErrorMessage = "Пароли не совпадают")]
        public string ReTypeUserAccountPassword { get; set; }
    }
}

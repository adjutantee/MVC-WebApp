using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress(ErrorMessage = "Укажите правильный Email")]
        public string exampleLoginEmail { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string exampleLoginPassword { get; set; }
        [Required(ErrorMessage = "Поле повторного ввода пароля не указан")]
        [Compare("exampleLoginPassword", ErrorMessage = "Пароли не совпадают")]
        public string exampleReTypeLoginPassword { get; set; }
    }
}

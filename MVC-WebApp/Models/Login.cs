using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress(ErrorMessage = "Укажите правильный Email")]
        public string exampleLoginEmail { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string exampleLoginPassword { get; set; }
        public bool exampleLoginCheckBox { get; set; }
        public string ReturnUrl { get; set; }
    }
}

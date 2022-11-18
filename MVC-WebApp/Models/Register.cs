using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string exampleRegisterName { get; set; }
        [Required(ErrorMessage = "Не указан номер телефона")]
        public string exampleRegisterNumberPhone { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress(ErrorMessage = "Укажите правильный Email")]
        public string exampleRegisterEmail { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string exampleRegisterPassword { get; set; }
        [Required(ErrorMessage = "Поле повторного ввода пароля не указан")]
        [Compare("exampleRegisterPassword", ErrorMessage = "Пароли не совпадают")]
        public string exampleReTypeRegisterPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Models
{
    public class ChangePassword
    {
        public string exampleLoginEmail { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле повторного ввода пароля не указан")]
        [Compare("exampleLoginPassword", ErrorMessage = "Пароли не совпадают")]
        public string ReTypePassword { get; set; }
    }
}

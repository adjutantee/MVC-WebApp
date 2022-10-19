using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Заполните поле правильно")]
        public string Name { get; set; }
    }
}

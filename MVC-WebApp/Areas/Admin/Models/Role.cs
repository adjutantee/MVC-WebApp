using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Areas.Admin.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Заполните поле правильно")]
        public string Name { get; set; }   
    }
}

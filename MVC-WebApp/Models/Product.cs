using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineWebApp_MVC.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Укажите имя товара")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните описание товара")]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Укажите цену товара")]
        public Decimal Cost { get; set; }
    }
}
 
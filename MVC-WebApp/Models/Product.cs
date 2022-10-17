using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineWebApp_MVC.Models
{
    public class Product
    {
        private static int instanceCounter = 1;
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите имя товара")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните описание товара")]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Укажите цену товара")]
        public Decimal Cost { get; set; }

        public Product()
        {
            Id = instanceCounter;
            instanceCounter += 1;
        }

        public Product(string name, string description, string imagePath, decimal cost) : this()
        {
            Name = name;
            Description = description;
            ImagePath = imagePath;
            Cost = cost;
        }
    }
}
 
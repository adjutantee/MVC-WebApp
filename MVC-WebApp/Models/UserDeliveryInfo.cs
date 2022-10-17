using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string userOrderName { get; set; }
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите правильный Email")]
        public string userOrderEmail { get; set; }
        [Required(ErrorMessage = "Не указан номер телефона")]
        public string userOrderPhone { get; set; }
        [Required(ErrorMessage = "Не указан адрес доставки")]
        public string userAdres { get; set; }
        public string userOrderMessage { get; set; }
    }
}

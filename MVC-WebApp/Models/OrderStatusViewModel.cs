using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Создан")]
        Created,
        [Display(Name = "Обработан")]
        Processed,
        [Display(Name = "В пути")]
        Delivering,
        [Display(Name = "Доставлен")]
        Delivered,
        [Display(Name = "Отменен")]
        Canceled
    }
}
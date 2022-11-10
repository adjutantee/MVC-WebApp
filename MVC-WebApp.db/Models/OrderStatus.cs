using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp.db.Models
{
    public enum OrderStatus
    {
        //[Display(Name = "Создан")]
        Created,
        //[Display(Name = "Обработан")]
        Processed,
        //[Display(Name = "В пути")]
        Delivering,
        //[Display(Name = "Доставлен")]
        Delivered,
        //[Display(Name = "Отменен")]
        Canceled
    }
}
using System;

namespace MVC_WebApp.db.Models
{
    public class UserDeliveryInfo
    {
        public Guid Id { get; set; }
        public string userOrderName { get; set; }
        public string userOrderEmail { get; set; }
        public string userOrderPhone { get; set; }
        public string userAdres { get; set; }
        public string userOrderMessage { get; set; }
    }
}

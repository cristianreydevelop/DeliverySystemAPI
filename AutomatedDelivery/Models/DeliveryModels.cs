using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedDelivery.Models
{
    public class DeliveryModels
    {
        public class DeleteDelivery
        {
            public int deliveryId { get; set; }
        }

        public class SaveDelivery
        {
            public int deliveryId { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string message { get; set; }
            public bool active { get; set; }
        }

        public class UpdateDelivery
        {
            public int deliveriesId { get; set; }
            public int deliveryId { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string message { get; set; }
            public bool active { get; set; }
        }

        public class GetDeliveries
        {
            public int deliveriesid { get; set; }
            public string info { get; set; }
        }
    }
}
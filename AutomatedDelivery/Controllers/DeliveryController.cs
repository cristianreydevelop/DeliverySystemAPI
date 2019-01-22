using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutomatedDelivery.Models;
using AutomatedDelivery.Code;

namespace AutomatedDelivery.Controllers
{
    public class DeliveryController : ApiController
    {
        [HttpGet]
        public DeliveryModels.UpdateDelivery GetDelivery(int DeliveriesId)
        {
            using (DeliveryHelper GetList = new DeliveryHelper())
            {
                return GetList.GetDelivery(DeliveriesId);
            }
        }

        [HttpGet]
        public List<DeliveryModels.GetDeliveries> GetDeliveries()
        {
            using (DeliveryHelper GetList = new DeliveryHelper())
            {
                return GetList.GetDeliveries();
            }
        }

        [HttpPost]
        public void SaveDelivery(DeliveryModels.SaveDelivery Delivery)
        {
            //var httpContext = (System.Web.HttpContextWrapper)Request.Properties["MS_HttpContext"];
            //var foo = httpContext.Request.Form["jsonRequest"];

            using(DeliveryHelper SaveDel = new DeliveryHelper())
            {
                SaveDel.InsertDelivery(Delivery);
            }
        }

        [AcceptVerbs("DELETE", "PUT")]
        public void UpdateDelivery(DeliveryModels.UpdateDelivery Delivery)
        {
            using (DeliveryHelper UpdateDel = new DeliveryHelper())
            {
                // If the from field is empty then we need to de-activate the delivery.
                if (string.IsNullOrEmpty(Delivery.from))
                {
                    UpdateDel.DeleteDelivery(Delivery.deliveriesId);
                }
                else
                {
                    UpdateDel.UpdateDelivery(Delivery);
                }
            }
        }
    }
}

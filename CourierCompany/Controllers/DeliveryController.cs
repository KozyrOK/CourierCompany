using System.Web.Mvc;
using CourierCompany.Models;

namespace CourierCompany.Controllers
{
    public class DeliveryController : Controller
    {
        [HttpGet]
        public ActionResult NewDelivery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewDelivery([Bind(Include = "DeliveryType,SenderName,SenderAddress,ReceiverName,ReceiverAddress")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                delivery.AddNewDelivery();
                int? idRating = delivery.AddRating();
                delivery.IdInBaseDeliveryRating = idRating;
                delivery.DeliveryModified();
                return View("DeliveryResult", delivery);
            }
            return View("NewDelivery");            
        }       
        
        public ActionResult FindDeliveryForID()
        {
            return View();
        }
                
        public ActionResult ViewDelivery(int? id)
        {
            if (id > 0 && id != null)
            {                
                Delivery delivery = new Delivery(id);        

                if (delivery.DeliveryId != null && delivery.IsPresentRating == false)                    
                    return View("DeliveryID", delivery);
                else if (delivery.IsPresentRating == true)
                    return View("DeliveryIDRating", delivery);
                else
                    return View("~/Views/Main/Main.cshtml");
            }
            return View("~/Views/Main/Main.cshtml");
        }        
    }
}

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
        public ActionResult NewDelivery(Delivery delivery)
        {
            delivery.AddNewDelivery();
            delivery.GetLastDeliveryId();
            return View("DeliveryResult", delivery);
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
                else
                    if (delivery.DeliveryType == (DeliveryType)0)
                        {
                        int? idInBaseDeliveryRating = delivery.IdInBaseDeliveryRating;
                        DeliveryFoodRating rating = new DeliveryFoodRating(idInBaseDeliveryRating);                        
                        return View("DeliveryIDRating", delivery);
                        }
                    else if (delivery.DeliveryType == (DeliveryType)1)
                        {
                        int? idInBaseDeliveryRating = delivery.IdInBaseDeliveryRating;
                        DeliveryFragileRating rating = new DeliveryFragileRating(idInBaseDeliveryRating);                        
                        return View("DeliveryIDRating", delivery);
                        }
                    else if (delivery.DeliveryType == (DeliveryType)2)
                        {
                        int? idInBaseDeliveryRating = delivery.IdInBaseDeliveryRating;
                        DeliveryEquipmentRating rating = new DeliveryEquipmentRating(idInBaseDeliveryRating);                       
                        return View("DeliveryIDRating", delivery);
                        }                    
            }
            return View("~Views/Main/Main.cshtml");
        }        
    }
}

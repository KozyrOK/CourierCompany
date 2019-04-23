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
       
        [HttpGet]
        public ActionResult FindForID()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindForID(int? id)
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
                        ViewBag.IsIntimeFood = rating.DeliveryFoodRatingId;
                        ViewBag.FreshFood = rating.FreshFood;
                        ViewBag.СorrectPackFood = rating.СorrectPackFood;
                        return View("DeliveryIDRating", delivery);
                        }
                    else if (delivery.DeliveryType == (DeliveryType)1)
                        {
                        int? idInBaseDeliveryRating = delivery.IdInBaseDeliveryRating;
                        DeliveryFragileRating rating = new DeliveryFragileRating(idInBaseDeliveryRating);
                        ViewBag.IsIntimeFragile = rating.IsIntimeFragile;
                        ViewBag.IsDefectFragile = rating.IsDefectFragile;
                        ViewBag.IsPackCompleteFragile = rating.IsPackCompleteFragile;
                        return View("DeliveryIDRating", delivery);
                        }
                    else if (delivery.DeliveryType == (DeliveryType)2)
                        {
                        int? idInBaseDeliveryRating = delivery.IdInBaseDeliveryRating;
                        DeliveryEquipmentRating rating = new DeliveryEquipmentRating(idInBaseDeliveryRating);
                        ViewBag.IsIntimeEquipment = rating.IsIntimeEquipment;
                        ViewBag.IsCompleteEquipment = rating.IsIntimeEquipment;
                        return View("DeliveryIDRating", delivery);
                        }                    
            }
            return View("Main");
        }        
    }
}

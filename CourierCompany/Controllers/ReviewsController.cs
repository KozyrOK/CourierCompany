using System.Collections.Generic;
using System.Web.Mvc;
using CourierCompany.Models;

namespace CourierCompany.Controllers
{
    public class ReviewsController : Controller
    {        
        public ActionResult ListAllDeliveryOrders()
        {
            Delivery delivery = new Delivery();
            List<Delivery> listAllDeliveryOrders = delivery.GetDeliveryOrders();
            return View(listAllDeliveryOrders); 
        }

        [HttpPost]
        public ActionResult ModifiedFoodRating(DeliveryFoodRating rating)
        {
            rating.DeliveryFoodRatingModified(); 
            int? id = rating.IdDelivery;
            Delivery delivery = new Delivery(id);
            delivery.IsPresentRating = true;            
            delivery.DeliveryModified();
            return View("~/Views/Delivery/DeliveryIDRating.cshtml", delivery);
        }

        [HttpPost]
        public ActionResult ModifiedFragileGoodsRating(DeliveryFragileGoodsRating rating)
        {
            rating.DeliveryFragileGoodsRatingModified();
            int? id = rating.IdDelivery;
            Delivery delivery = new Delivery(id);
            delivery.IsPresentRating = true;
            delivery.DeliveryModified();
            return View("~/Views/Delivery/DeliveryIDRating.cshtml", delivery);
        }

        [HttpPost]
        public ActionResult ModifiedEquipmentRating(DeliveryEquipmentRating rating)
        {
            rating.DeliveryEquipmentRatingModified();
            int? id = rating.IdDelivery;
            Delivery delivery = new Delivery(id);
            delivery.IsPresentRating = true;            
            delivery.DeliveryModified();
            return View("~/Views/Delivery/DeliveryIDRating.cshtml", delivery);
        }       

    }
}
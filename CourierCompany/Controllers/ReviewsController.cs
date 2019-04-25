using System.Collections.Generic;
using System.Web.Mvc;
using CourierCompany.Models;

namespace CourierCompany.Controllers
{
    public class ReviewsController : Controller
    {        
        public ActionResult ListReviews()
        {
            Delivery delivery = new Delivery();
            List<Delivery> reviews = delivery.GetAllReviews();
            return View(reviews); 
        }

        [HttpPost]
        public ActionResult AddFoodRating(DeliveryFoodRating rating)
        {
            rating.AddDeliveryFoodRating();
            int? id = rating.GetLastDeliveryFoodRatingId();
            Delivery delivery = new Delivery();
            delivery.SetIdInBaseDeliveryRating(id);
            return View("~/Views/Delivery/DeliveryIDRating.cshtml", delivery);
        }

        [HttpPost]
        public ActionResult AddFragileRating(DeliveryFragileRating rating)
        {
            rating.AddDeliveryFragileRating();
            int? id = rating.GetLastDeliveryFragileRatingId();
            Delivery delivery = new Delivery();
            delivery.SetIdInBaseDeliveryRating(id);
            return View("~/Views/Delivery/DeliveryIDRating.cshtml", delivery);
        }

        [HttpPost]
        public ActionResult AddEquipmentRating(DeliveryEquipmentRating rating)
        {
            rating.AddDeliveryEquipmentRating();
            int? id = rating.GetLastDeliveryEquipmentRatingId();
            Delivery delivery = new Delivery();
            delivery.SetIdInBaseDeliveryRating(id);
            return View("~/Views/Delivery/DeliveryIDRating.cshtml", delivery);
        }       

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace CourierCompany.Models
{
    public class Delivery
    {
        [Key]
        public int? DeliveryId { get; set; }
        public DeliveryType DeliveryType { get; set; }        
        public string SenderName { get; set; }        
        public string SenderAddress { get; set; }        
        public string ReceiverName { get; set; }        
        public string ReceiverAddress { get; set; }
        public int? IdInBaseDeliveryRating { get; set; }
        public bool IsPresentRating { get; set; }

        public Delivery() { }
        public Delivery(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                var temp = context.Deliveries.Find(id);
                if (temp != null)
                {
                    DeliveryId = temp.DeliveryId;
                    DeliveryType = temp.DeliveryType;
                    SenderName = temp.SenderName;
                    SenderAddress = temp.SenderAddress;
                    ReceiverName = temp.ReceiverName;
                    ReceiverAddress = temp.ReceiverAddress;
                    IdInBaseDeliveryRating = temp.IdInBaseDeliveryRating;
                    IsPresentRating = temp.IsPresentRating;
                }
            }
        }        

        public void AddNewDelivery()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.Deliveries.Add(this);
                context.SaveChanges();
                int? LastId = context.Deliveries.Count();
                DeliveryId = LastId;
            }
        }

        public int? AddRating()
        {
            int? idRating = null;

            if (DeliveryType == (DeliveryType)0)
            {
                DeliveryFoodRating rating = new DeliveryFoodRating();
                rating.IdDelivery = DeliveryId;                
                idRating = rating.AddDeliveryFoodRating();
            }

            else if (DeliveryType == (DeliveryType)1)
            {
                DeliveryFragileRating rating = new DeliveryFragileRating();
                rating.IdDelivery = DeliveryId;
                idRating = rating.AddDeliveryFragileRating();                
            }

            else if (DeliveryType == (DeliveryType)2)
            {
                DeliveryEquipmentRating rating = new DeliveryEquipmentRating();
                rating.IdDelivery = DeliveryId;
                idRating = rating.AddDeliveryEquipmentRating();
            }
            return idRating;
        }        

        public void DeliveryModified()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Delivery> GetAllReviews()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                return context.Deliveries.OrderBy(d => d.DeliveryId).ToList();
            }
        }
    }
}            

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
            }
        }

        public int GetLastDeliveryId()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                int id = context.Deliveries.Count();
                return id;
            }
        }

        public void SetIdInBaseDeliveryRating(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                Delivery delivery = new Delivery(id)
                {
                    IdInBaseDeliveryRating = (int)id,
                    IsPresentRating = true
                };

                context.Entry(delivery).State = EntityState.Modified;
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

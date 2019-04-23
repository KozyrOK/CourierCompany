using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CourierCompany.Models
{
    public class DeliveryEquipmentRating
    {
        [Key]
        public int? DeliveryEquipmentRatingId { get; set; }
        public int DeliveryId { get; set; }
        public bool IsIntimeEquipment { get; set; }
        public bool IsCompleteEquipment { get; set; }


        public DeliveryEquipmentRating() { }

        public DeliveryEquipmentRating(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                var temp = context.DeliveryEquipmentRatings.Find(id);
                if (temp != null)
                {
                    DeliveryEquipmentRatingId = temp.DeliveryEquipmentRatingId;
                    DeliveryId = temp.DeliveryId;
                    IsIntimeEquipment = temp.IsIntimeEquipment;
                    IsCompleteEquipment = temp.IsCompleteEquipment;
                }
            }
        }

        public void AddDeliveryEquipmentRating()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.DeliveryEquipmentRatings.Add(this);
                context.SaveChanges();
            }
        }

        public int GetLastDeliveryEquipmentRatingId()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                int id = context.DeliveryEquipmentRatings.Count();
                return id;
            }
        }
    }
}
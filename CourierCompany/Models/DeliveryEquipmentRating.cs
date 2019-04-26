using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace CourierCompany.Models
{
    public class DeliveryEquipmentRating
    {
        [Key]
        public int? DeliveryEquipmentRatingId { get; set; }
        public int? IdDelivery { get; set; }
        public bool IsIntimeEquipment { get; set; }
        public bool IsCompleteEquipment { get; set; }
        public byte CommonDeliveryRaiting { get; set; }
        public string TextComment { get; set; }


        public DeliveryEquipmentRating() { }

        public DeliveryEquipmentRating(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                var temp = context.DeliveryEquipmentRatings.Find(id);
                if (temp != null)
                {
                    DeliveryEquipmentRatingId = temp.DeliveryEquipmentRatingId;
                    IdDelivery = temp.IdDelivery;
                    IsIntimeEquipment = temp.IsIntimeEquipment;
                    IsCompleteEquipment = temp.IsCompleteEquipment;
                    CommonDeliveryRaiting = temp.CommonDeliveryRaiting;
                    TextComment = temp.TextComment;
                }
            }
        }        

        public int? AddDeliveryEquipmentRating()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.DeliveryEquipmentRatings.Add(this);
                context.SaveChanges();
                int? LastId = context.DeliveryEquipmentRatings.Count();
                return LastId;
            }
        }

        public void DeliveryEquipmentRatingModified()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
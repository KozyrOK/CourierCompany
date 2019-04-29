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
        [Display(Name = "Timely delivery")]
        public bool IsIntimeEquipment { get; set; }
        [Display(Name = "Equipment completeness")]
        public bool IsCompleteEquipment { get; set; }
        [Display(Name = "Common delivery raiting")]
        [Range (0, 10)]
        public byte CommonDeliveryRaitingEquipment { get; set; }
        [Display(Name = "Comment")]
        [MaxLength (200)]
        public string TextCommentEquipment { get; set; }


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
                    CommonDeliveryRaitingEquipment = temp.CommonDeliveryRaitingEquipment;
                    TextCommentEquipment = temp.TextCommentEquipment;
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
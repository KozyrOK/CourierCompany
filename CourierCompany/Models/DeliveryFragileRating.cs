using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace CourierCompany.Models
{
    public class DeliveryFragileRating
    {
        [Key]        
        public int? DeliveryFragileRatingId { get; set; }
        public int? IdDelivery { get; set; }
        public bool IsIntimeFragile { get; set; }
        public bool IsDefectFragile { get; set; }        
        public byte IsPackCompleteFragile { get; set; }
        public byte CommonDeliveryRaiting { get; set; }
        public string TextComment { get; set; }

        public DeliveryFragileRating() { }

        public DeliveryFragileRating(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                var temp = context.DeliveryFragileRatings.Find(id);
                if (temp != null)
                {
                    DeliveryFragileRatingId = temp.DeliveryFragileRatingId;
                    IdDelivery = temp.IdDelivery;
                    IsIntimeFragile = temp.IsIntimeFragile;
                    IsDefectFragile = temp.IsDefectFragile;
                    IsPackCompleteFragile = temp.IsPackCompleteFragile;
                    CommonDeliveryRaiting = temp.CommonDeliveryRaiting;
                    TextComment = temp.TextComment;
                }
            }
        }        

        public int? AddDeliveryFragileRating()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.DeliveryFragileRatings.Add(this);
                context.SaveChanges();
                int? LastId = context.DeliveryFragileRatings.Count();
                return LastId;
            }
        }

        public void DeliveryFragileRatingModified()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
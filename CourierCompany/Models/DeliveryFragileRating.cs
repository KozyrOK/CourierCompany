using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CourierCompany.Models
{
    public class DeliveryFragileRating
    {
        [Key]        
        public int? DeliveryFragileRatingId { get; set; }
        public int DeliveryId { get; set; }
        public bool IsIntimeFragile { get; set; }
        public bool IsDefectFragile { get; set; }
        [Range(1, 10)]
        public byte IsPackCompleteFragile { get; set; }

        public DeliveryFragileRating() { }

        public DeliveryFragileRating(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                var temp = context.DeliveryFragileRatings.Find(id);
                if (temp != null)
                {
                    DeliveryFragileRatingId = temp.DeliveryFragileRatingId;
                    DeliveryId = temp.DeliveryId;
                    IsIntimeFragile = temp.IsIntimeFragile;
                    IsDefectFragile = temp.IsDefectFragile;
                    IsPackCompleteFragile = temp.IsPackCompleteFragile;
                }
            }
        }

        public void AddDeliveryFragileRating()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.DeliveryFragileRatings.Add(this);
                context.SaveChanges();
            }
        }

        public int GetLastDeliveryFragileRatingId()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                int id = context.DeliveryFragileRatings.Count();
                return id;
            }
        }
    }
}
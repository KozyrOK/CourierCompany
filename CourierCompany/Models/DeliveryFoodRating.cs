using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CourierCompany.Models
{
    public class DeliveryFoodRating
    {
        [Key]        
        public int? DeliveryFoodRatingId { get; set; }
        public int DeliveryId { get; set; }
        public bool IsIntimeFood { get; set; }
        [Range(1, 10)]
        public byte FreshFood { get; set; }
        [Range(1, 10)]
        public byte СorrectPackFood { get; set; }

        public DeliveryFoodRating() { }

        public DeliveryFoodRating(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                var temp = context.DeliveryFoodRatings.Find(id);
                if (temp != null)
                {
                    DeliveryFoodRatingId = temp.DeliveryFoodRatingId;
                    DeliveryId = temp.DeliveryId;
                    IsIntimeFood = temp.IsIntimeFood;
                    FreshFood = temp.FreshFood;
                    СorrectPackFood = temp.СorrectPackFood;
                }
            }
        }

        public void AddDeliveryFoodRating()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.DeliveryFoodRatings.Add(this);
                context.SaveChanges();
            }
        }

        public int GetLastDeliveryFoodRatingId()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                int id = context.DeliveryFoodRatings.Count();
                return id;
            }
        }
    }
}
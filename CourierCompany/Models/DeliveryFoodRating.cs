using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace CourierCompany.Models
{
    public class DeliveryFoodRating
    {
        [Key]        
        public int? DeliveryFoodRatingId { get; set; }
        public int? IdDelivery { get; set; }
        public bool IsIntimeFood { get; set; }        
        public byte FreshFood { get; set; }        
        public byte СorrectPackFood { get; set; }
        public byte CommonDeliveryRaiting { get; set; }        
        public string TextComment { get; set; }

        public DeliveryFoodRating() { }

        public DeliveryFoodRating(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                var temp = context.DeliveryFoodRatings.Find(id);
                if (temp != null)
                {
                    DeliveryFoodRatingId = temp.DeliveryFoodRatingId;
                    IdDelivery = temp.IdDelivery;
                    IsIntimeFood = temp.IsIntimeFood;
                    FreshFood = temp.FreshFood;
                    СorrectPackFood = temp.СorrectPackFood;
                    CommonDeliveryRaiting = temp.CommonDeliveryRaiting;
                    TextComment = temp.TextComment;
                }
            }
        }

        public int? AddDeliveryFoodRating()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {                
                context.DeliveryFoodRatings.Add(this);
                context.SaveChanges();
                int? LastId = context.DeliveryFoodRatings.Count();
                return LastId;
            }
        }        

        public void DeliveryFoodRatingModified()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {                
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }
        }        
    }
}
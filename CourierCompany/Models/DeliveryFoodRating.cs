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
        [Display(Name = "Timely delivery")]
        public bool IsIntimeFood { get; set; }
        [Display(Name = "Food freshness")]
        [Range(0, 10)]
        public byte FreshFood { get; set; }
        [Display(Name = "Correct packaging")]
        [Range(0, 10)]
        public byte СorrectPackFood { get; set; }
        [Display(Name = "Common delivery raiting")]
        [Range(0, 10)]
        public byte CommonDeliveryRaiting { get; set; }
        [Display(Name = "Comment")]
        [MaxLength(200)]
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
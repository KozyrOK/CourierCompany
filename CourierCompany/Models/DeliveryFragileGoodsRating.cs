using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace CourierCompany.Models
{
    public class DeliveryFragileGoodsRating
    {
        [Key]        
        public int? DeliveryFragileGoodsRatingId { get; set; }
        public int? IdDelivery { get; set; }
        [Display(Name = "Timely delivery")]        
        public bool IsIntimeFragileGoods { get; set; }
        [Display(Name = "Presence of defects")]
        public bool IsDefectFragileGoods { get; set; }
        [Display(Name = "Package integrity")]
        [Range(0, 10)]
        public byte IsPackCompleteFragileGoods { get; set; }
        [Display(Name = "Common delivery raiting")]
        [Range(0, 10)]
        public byte CommonDeliveryRaitingFragileGoods { get; set; }
        [Display(Name = "Comment")]
        [MaxLength(200)]
        public string TextCommentFragileGoods { get; set; }

        public DeliveryFragileGoodsRating() { }

        public DeliveryFragileGoodsRating(int? id)
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                var temp = context.DeliveryFragileGoodsRatings.Find(id);
                if (temp != null)
                {
                    DeliveryFragileGoodsRatingId = temp.DeliveryFragileGoodsRatingId;
                    IdDelivery = temp.IdDelivery;
                    IsIntimeFragileGoods = temp.IsIntimeFragileGoods;
                    IsDefectFragileGoods = temp.IsDefectFragileGoods;
                    IsPackCompleteFragileGoods = temp.IsPackCompleteFragileGoods;
                    CommonDeliveryRaitingFragileGoods = temp.CommonDeliveryRaitingFragileGoods;
                    TextCommentFragileGoods = temp.TextCommentFragileGoods;
                }
            }
        }        

        public int? AddDeliveryFragileGoodsRating()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.DeliveryFragileGoodsRatings.Add(this);
                context.SaveChanges();
                int? LastId = context.DeliveryFragileGoodsRatings.Count();
                return LastId;
            }
        }

        public void DeliveryFragileGoodsRatingModified()
        {
            using (CourierCompanyContext context = new CourierCompanyContext())
            {
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
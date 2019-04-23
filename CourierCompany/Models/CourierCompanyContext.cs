using System.Data.Entity;

namespace CourierCompany.Models
{
    public class CourierCompanyContext : DbContext
    {
        public DbSet<Delivery> Deliveries { get; set; }        
        public DbSet<DeliveryFoodRating> DeliveryFoodRatings { get; set; }
        public DbSet<DeliveryEquipmentRating> DeliveryEquipmentRatings { get; set; }
        public DbSet<DeliveryFragileRating> DeliveryFragileRatings { get; set; }
    }
}
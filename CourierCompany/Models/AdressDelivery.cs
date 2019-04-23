using System.ComponentModel.DataAnnotations;

namespace CourierCompany.Models
{
    public class AdressDelivery
    {
        [Key]        
        public int? Id { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }        
    }
}
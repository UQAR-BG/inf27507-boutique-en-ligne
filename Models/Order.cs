using System.ComponentModel.DataAnnotations;

namespace INF27507_Boutique_En_Ligne.Models
{
    public class Order : IModel
    {
        [Required]
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}

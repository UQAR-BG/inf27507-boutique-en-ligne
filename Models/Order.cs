using INF27507_Boutique_En_Ligne.Models.Enums;

namespace INF27507_Boutique_En_Ligne.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public DateTime CreationDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}

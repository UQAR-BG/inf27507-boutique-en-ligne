namespace INF27507_Boutique_En_Ligne.Models
{
    public class Cart : IModel
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<CartItem> Items { get; set; }
        public bool Active { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}

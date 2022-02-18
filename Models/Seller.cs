namespace INF27507_Boutique_En_Ligne.Models
{
    public class Seller : User
    {
        public ICollection<Product> Products { get; set; }

        public Seller()
        {
            Products = new List<Product>();
        }
    }
}

namespace INF27507_Boutique_En_Ligne.Models
{
    public class Client : User
    {
        public double Balance { get; set; }
        public ICollection<Cart> Carts { get; set; }

        public Client()
        {
            Carts = new List<Cart>();
        }
    }
}

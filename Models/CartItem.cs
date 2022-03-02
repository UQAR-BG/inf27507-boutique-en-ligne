namespace INF27507_Boutique_En_Ligne.Models
{
    public class CartItem : IModel
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double SalePrice { get; set; }
        public int Quantity { get; set; }
    }
}

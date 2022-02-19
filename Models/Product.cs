namespace INF27507_Boutique_En_Ligne.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}

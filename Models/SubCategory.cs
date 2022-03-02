namespace INF27507_Boutique_En_Ligne.Models
{
    public class SubCategory : IModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

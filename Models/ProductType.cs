namespace INF27507_Boutique_En_Ligne.Models
{
    public class ProductType : IModel
    {
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace INF27507_Boutique_En_Ligne.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public int UsageId { get; set; }
        public Usage Usage { get; set; }
        [Required]
        public int ColourId { get; set; }
        public Colour Colour { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        [Required]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}

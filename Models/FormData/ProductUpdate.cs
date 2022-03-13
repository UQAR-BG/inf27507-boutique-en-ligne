using System.ComponentModel.DataAnnotations;

namespace INF27507_Boutique_En_Ligne.Models
{
    public class ProductUpdate
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
    }
}

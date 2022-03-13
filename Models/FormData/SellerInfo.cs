using System.ComponentModel.DataAnnotations;

namespace INF27507_Boutique_En_Ligne.Models.FormData
{
    public class SellerInfo
    {
        [Required, StringLength(32, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required, StringLength(32, MinimumLength = 2)]
        public string Firstname { get; set; }

        public string? Identifiant { get; set; }
    }
}

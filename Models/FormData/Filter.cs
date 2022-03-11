namespace INF27507_Boutique_En_Ligne.Models.FormData;

public class Filter
{
    public int? Price { get; set; }

    public int Min { get; set; }

    public int Max { get; set; }

    public int? CategoryID { get; set; }
    public Dictionary<Gender, bool>? Genders { get; set; }
    public Dictionary<int, bool>? GendersBools { get; set; }
}
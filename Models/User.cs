namespace INF27507_Boutique_En_Ligne.Models
{
    public abstract class User : IModel
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}

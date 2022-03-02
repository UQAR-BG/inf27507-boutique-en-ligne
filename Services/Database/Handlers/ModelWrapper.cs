using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class ModelWrapper
    {
        public IModel Model { get; set; }
        public int ClientId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}

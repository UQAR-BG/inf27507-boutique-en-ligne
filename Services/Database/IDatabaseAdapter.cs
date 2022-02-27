using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services.Database
{
    public interface IDatabaseAdapter
    {
        Client GetClient(int Id);
        List<Product> GetProducts();
        Product GetProduct(int id);
    }
}

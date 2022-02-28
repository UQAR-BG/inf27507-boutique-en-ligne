using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services
{
    public interface IDatabaseAdapter
    {
        Client GetClient(int Id);
        List<Product> GetProducts();
        Product GetProduct(int id);
        Cart GetActiveCart(int clientId);
        Cart CreateActiveCart(int clientId);
        Cart CreateActiveCartIfNotExist(int clientId);
        void AddItem(int clientId, int productId, int quantity);
    }
}

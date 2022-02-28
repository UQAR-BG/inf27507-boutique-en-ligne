using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class MySQLDatabaseAdapter : IDatabaseAdapter
    {
        private readonly BoutiqueMySQLService service;

        public MySQLDatabaseAdapter()
        {
            service = new BoutiqueMySQLService();
        }

        public Client GetClient(int Id)
        {
            return service.GetClient(Id);
        }

        public Cart GetActiveCart(int clientId)
        {
            return service.GetActiveCart(clientId);
        }

        public Cart CreateActiveCart(int clientId)
        {
            return service.CreateActiveCart(clientId);
        }

        public Cart CreateActiveCartIfNotExist(int clientId)
        {
            return service.CreateActiveCartIfNotExist(clientId);
        }

        public void AddItem(int clientId, int productId, int quantity)
        {
            service.AddItem(clientId, productId, quantity);
        }

        public List<Product> GetProducts()
        {
            return service.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return service.GetProduct(id);
        }
    }
}

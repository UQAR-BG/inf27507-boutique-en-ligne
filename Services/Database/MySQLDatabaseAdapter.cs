using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services.Database
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

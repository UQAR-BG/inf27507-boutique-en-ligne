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

        public List<Product> GetProducts()
        {
            return service.GetAllProducts();
        }
    }
}

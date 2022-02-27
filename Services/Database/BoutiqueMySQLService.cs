using INF27507_Boutique_En_Ligne.Models;
using Microsoft.EntityFrameworkCore;

namespace INF27507_Boutique_En_Ligne.Services.Database
{
    public class BoutiqueMySQLService
    {
        private readonly BoutiqueDbContext _dbContext;

        public BoutiqueMySQLService()
        {
            _dbContext = new BoutiqueDbContext();
        }

        public Client GetClient(int Id)
        {
            return _dbContext.Clients
                .Include(c => c.Carts)
                .FirstOrDefault(c => c.Id == Id);
        }

        /*public bool ClientHasActiveCart(int Id)
        {

        }*/

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products
                .Include(p => p.Colour)
                .Include(p => p.Seller)
                .ToList();
        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products
                .Include(p => p.Colour)
                .Include(p => p.Seller)
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Include(p => p.ProductType)
                .Include(p => p.Usage)
                .Include(p => p.Gender)
                .SingleOrDefault(p => p.Id == id);
        }
    }
}

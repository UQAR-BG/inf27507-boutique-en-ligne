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

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products
                .Include(p => p.Colour)
                .Include(p => p.Seller)
                .ToList();
        }
    }
}

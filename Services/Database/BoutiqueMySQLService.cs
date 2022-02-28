using INF27507_Boutique_En_Ligne.Models;
using Microsoft.EntityFrameworkCore;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class BoutiqueMySQLService
    {
        private readonly BoutiqueDbContext _dbContext;

        public BoutiqueMySQLService()
        {
            _dbContext = new BoutiqueDbContext();
        }

        public Client GetClient(int id)
        {
            return _dbContext.Clients
                .Include(c => c.Carts)
                .FirstOrDefault(c => c.Id == id);
        }

        public Cart GetActiveCart(int clientId)
        {
            return (from carts in _dbContext.Cart
                   where carts.ClientId == clientId && carts.Active
                   select carts).SingleOrDefault();
        }

        public Cart CreateActiveCart(int clientId)
        {
            Cart cart = new Cart() { ClientId = clientId, Active = true };
            _dbContext.Cart.Add(cart);
            _dbContext.SaveChanges();

            return cart;
        }

        public Cart CreateActiveCartIfNotExist(int clientId)
        {
            Cart cart = GetActiveCart(clientId);
            if (cart == null)
                cart = CreateActiveCart(clientId);

            return cart;
        }

        public void AddItem(int clientId, int productId, int quantity)
        {
            Cart cart = GetActiveCart(clientId);
            Product product = GetProductForValidation(productId);

            if (product != null && cart != null)
            {
                CartItem item = new CartItem() { CartId = cart.Id, ProductId = product.Id, Quantity = quantity };
                _dbContext.CartItems.Add(item);
                _dbContext.SaveChanges(true);
            }
        }

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

        private Product GetProductForValidation(int id)
        {
            return _dbContext.Products.Find(id);
        }
    }
}

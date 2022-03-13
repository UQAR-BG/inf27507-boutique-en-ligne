using INF27507_Boutique_En_Ligne.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class BoutiqueMySQLService
    {
        private readonly BoutiqueDbContext _dbContext;

        public BoutiqueDbContext GetContext()
        {
            return _dbContext;
        }

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
        
        public List<Client> GetClients()
        {
            return _dbContext.Clients
                .Include(c => c.Carts).ToList();
        }
        
        public void AddClient(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges(true);
        }

        public Seller GetSeller(int id)
        {
            return _dbContext.Sellers
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Seller> GetSellers()
        {
            return _dbContext.Sellers.ToList();
        }

        public void AddSeller(Seller seller)
        {
            _dbContext.Sellers.Add(seller);
            _dbContext.SaveChanges(true);
        }

        public void UpdateClientBalance(Client client, double amountToPay)
        {
            client.Balance -= amountToPay;
            _dbContext.SaveChanges();
        }

        public Cart GetActiveCart(int clientId)
        {
            return (from carts in _dbContext.Cart
                   where carts.ClientId == clientId && carts.Active
                   select carts).SingleOrDefault();
        }

        public double GetCartTotal(int cartId)
        {
            return (from carts in _dbContext.Cart
                    join item in _dbContext.CartItems on carts.Id equals item.CartId
                    join product in _dbContext.Products on item.ProductId equals product.Id
                    where carts.Id == cartId
                    select item).Sum(i => i.Product.Price * i.Quantity);
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

        public List<CartItem> GetCartItems(int cartId)
        {
            return (from item in _dbContext.CartItems
                    join product in _dbContext.Products on item.ProductId equals product.Id
                    where item.CartId == cartId
                    select item).ToList();
        }

        public CartItem GetCartItem(int cartId, int productId)
        {
            return (from item in _dbContext.CartItems
                    join product in _dbContext.Products on item.ProductId equals product.Id
                    where item.CartId == cartId && item.ProductId == productId
                    select item).SingleOrDefault();
        }

        public void AddItem(int clientId, int productId, int quantity)
        {
            IModelHandler modelHandler = new AddCartItemHandler();
            modelHandler.ExecuteOperation(new ModelWrapper()
            {
                ClientId = clientId,
                ProductId = productId,
                Quantity = quantity
            });
        }

        public void AddItem(CartItem item)
        {
            _dbContext.CartItems.Add(item);
            _dbContext.SaveChanges(true);
        }

        public void UpdateItem(int clientId, int productId, int quantity)
        {
            IModelHandler modelHandler = new UpdateCartItemHandler();
            modelHandler.ExecuteOperation(new ModelWrapper() {
                ClientId = clientId,
                ProductId = productId,
                Quantity = quantity
            });
        }

        public void UpdateItem(CartItem item, int quantity)
        {
            item.Quantity = quantity;
            _dbContext.SaveChanges();
        }

        public void DeleteItem(int clientId, int productId)
        {
            IModelHandler modelHandler = new RemoveCartItemHandler();
            modelHandler.ExecuteOperation(new ModelWrapper() {
                ClientId = clientId,
                ProductId = productId
            });
        }

        public void DeleteItem(CartItem item)
        {
            _dbContext.CartItems.Remove(item);
            _dbContext.SaveChanges();
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

        public Product GetProductForValidation(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public Product UpdateProduct(ProductUpdate update)
        {
            Product product = _dbContext.Products.Find(update.Id);

            if (product != null && (!product.Title.Equals(update.Title) || product.Price != update.Price))
            {
                product.Title = update.Title;
                product.Price = update.Price;

                _dbContext.SaveChanges();
            }

            return product;
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            return _dbContext.PaymentMethods.ToList();
        }

        public Order GetOrder(int id)
        {
            BoutiqueDbContext db = new BoutiqueDbContext();

            return db.Orders
                .Include(o => o.Cart)
                    .ThenInclude(o => o.Client)
                .Include(o => o.Cart)
                    .ThenInclude(c => c.Items)
                        .ThenInclude(i => i.Product)
                            .ThenInclude(p => p.Seller)
                .Include(o => o.PaymentMethod)
                .Where(o => o.Id == id)
                .SingleOrDefault();
        }

        public List<Order> GetOrders(Client client)
        {
            return _dbContext.Orders
                .Include(o => o.Cart)
                    .ThenInclude(c => c.Items)
                .Include(o => o.PaymentMethod)
                .Where(o => o.Cart.ClientId == client.Id && !o.Cart.Active)
                .OrderByDescending(o => o.CreationDate)
                .ToList();
        }

        public List<Order> GetOrders(Seller seller)
        {
            return (from orders in _dbContext.Orders
                    join methods in _dbContext.PaymentMethods on orders.PaymentMethodId equals methods.Id
                    join carts in _dbContext.Cart on orders.CartId equals carts.Id
                    join items in _dbContext.CartItems on carts.Id equals items.CartId
                    join products in _dbContext.Products on items.ProductId equals products.Id
                    join sellers in _dbContext.Sellers on products.SellerId equals sellers.Id
                    where sellers.Id == seller.Id && !carts.Active
                    select orders).ToList();
        }

        public int CreateOrder(int clientId, PaymentMethod method)
        {
            Cart activeCart = GetActiveCart(clientId);

            Order order = new Order() { CreationDate = DateTime.Now, CartId = activeCart.Id, PaymentMethodId = method.Id };
            _dbContext.Orders.Add(order);

            SaveActiveCart(activeCart);

            _dbContext.SaveChanges(true);
            return order.Id;
        }

        public List<Gender> GetGenders()
        {
            return _dbContext.Genders.ToList();
        }

        public List<Category> GetCategorys()
        {
            return _dbContext.Categories.ToList();
        }

        private void SaveActiveCart(Cart activeCart)
        {
            List<CartItem> items = GetCartItems(activeCart.Id);
            foreach (CartItem item in items)
                item.SalePrice = item.Product.Price;

            activeCart.Active = false;
        }

        public void UpdateClientInfo(Client client)
        {
            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
        }
    }
}

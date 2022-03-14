using INF27507_Boutique_En_Ligne.Models;
using Microsoft.EntityFrameworkCore;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class MySQLDatabaseAdapter : IDatabaseAdapter
    {
        private readonly BoutiqueMySQLService service;

        public DbContext GetContext()
        {
            return service.GetContext();
        }

        public MySQLDatabaseAdapter()
        {
            service = new BoutiqueMySQLService();
        }

        public Client GetClient(int Id)
        {
            return service.GetClient(Id);
        }

        public void UpdateClientInfo(Client client)
        {
            service.UpdateClientInfo(client);
        }

        public List<Client> GetSellers()
        {
            return service.GetClients();
        }

        public void AddClient(Client client)
        {
            service.AddClient(client);
        }

        public Seller GetSeller(int id)
        {
            return service.GetSeller(id);
        }

        public void UpdateClientBalance(Client client, double amountToPay)
        {
            service.UpdateClientBalance(client, amountToPay);
        }

        public Cart GetActiveCart(int clientId)
        {
            return service.GetActiveCart(clientId);
        }

        public double GetCartTotal(int cartId)
        {
            return service.GetCartTotal(cartId);
        }

        public Cart CreateActiveCart(int clientId)
        {
            return service.CreateActiveCart(clientId);
        }

        public Cart CreateActiveCartIfNotExist(int clientId)
        {
            return service.CreateActiveCartIfNotExist(clientId);
        }

        public List<CartItem> GetCartItems(int cartId)
        {
            return service.GetCartItems(cartId);
        }

        public CartItem GetCartItem(int cartId, int productId)
        {
            return service.GetCartItem(cartId, productId);
        }

        public void AddItem(int clientId, int productId, int quantity)
        {
            service.AddItem(clientId, productId, quantity);
        }

        public void AddItem(CartItem item)
        {
            service.AddItem(item);
        }

        public void UpdateItem(int clientId, int productId, int quantity)
        {
            service.UpdateItem(clientId, productId, quantity);
        }

        public void UpdateItem(CartItem item, int quantity)
        {
            service.UpdateItem(item, quantity);
        }

        public void RemoveItem(int clientId, int productId)
        {
            service.DeleteItem(clientId, productId);
        }

        public void RemoveItem(CartItem item)
        {
            service.DeleteItem(item);
        }

        public List<Product> GetProducts()
        {
            return service.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return service.GetProduct(id);
        }

        public Product GetProductForValidation(int id)
        {
            return service.GetProductForValidation(id);
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            return service.GetPaymentMethods();
        }

        public Order GetOrder(int id)
        {
            return service.GetOrder(id);
        }

        public List<Order> GetOrders(Client client)
        {
            return service.GetOrders(client);
        }

        public List<Order> GetOrders(Seller seller)
        {
            return service.GetOrders(seller);
        }

        public int CreateOrder(int clientId, PaymentMethod method)
        {
            return service.CreateOrder(clientId, method);
        }

        public List<Gender> GetGenders()
        {
            return service.GetGenders();
        }

        public List<Category> GetCategorys()
        {
            return service.GetCategorys();
        }
    }
}

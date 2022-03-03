using INF27507_Boutique_En_Ligne.Models;
using Microsoft.EntityFrameworkCore;

namespace INF27507_Boutique_En_Ligne.Services
{
    public interface IDatabaseAdapter
    {
        DbContext GetContext();
        Client GetClient(int Id);
        void UpdateClientBalance(Client client, double amountToPay);
        List<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProductForValidation(int id);
        Cart GetActiveCart(int clientId);
        double GetCartTotal(int cartId);
        Cart CreateActiveCart(int clientId);
        Cart CreateActiveCartIfNotExist(int clientId);
        List<CartItem> GetCartItems(int cartId);
        CartItem GetCartItem(int cartId, int productId);
        void AddItem(int clientId, int productId, int quantity);
        void AddItem(CartItem item);
        void UpdateItem(int clientId, int productId, int quantity);
        void UpdateItem(CartItem item, int quantity);
        void RemoveItem(int clientId, int productId);
        void RemoveItem(CartItem item);
        List<PaymentMethod> GetPaymentMethods();
        void CreateOrder(int clientId, PaymentMethod method);
    }
}

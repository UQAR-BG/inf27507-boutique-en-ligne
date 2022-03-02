using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class AddCartItemHandler : CartItemHandler
    {
        public override void Operation()
        {
            CartItem item;

            if (_modelWrapper.Model == null)
            {
                item = new CartItem() { 
                    CartId = _modelWrapper.CartId, 
                    ProductId = _modelWrapper.ProductId, 
                    Quantity = _modelWrapper.Quantity 
                };

                _database.AddItem(item);
            }
            else
            {
                item = (CartItem)_modelWrapper.Model;
                int newQuantity = item.Quantity + _modelWrapper.Quantity;

                _database.UpdateItem(item, newQuantity);
            }
        }
    }
}

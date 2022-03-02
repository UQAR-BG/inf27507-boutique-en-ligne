using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class UpdateCartItemHandler : CartItemHandler
    {
        public override void Operation()
        {
            if (_modelWrapper.Model != null)
            {
                _database.UpdateItem((CartItem)_modelWrapper.Model, _modelWrapper.Quantity);
            }
        }
    }
}

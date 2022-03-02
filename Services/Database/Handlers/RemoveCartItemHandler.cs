using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services
{
    public class RemoveCartItemHandler : CartItemHandler
    {
        public override void Operation()
        {
            if (_modelWrapper.Model != null)
            {
                _database.RemoveItem((CartItem)_modelWrapper.Model);
            }
        }
    }
}

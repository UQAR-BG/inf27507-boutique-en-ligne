using INF27507_Boutique_En_Ligne.Models;

namespace INF27507_Boutique_En_Ligne.Services
{
    public abstract class CartItemHandler : ModelHandler
    {
        protected ModelWrapper _modelWrapper;

        public override void ExecuteOperation(ModelWrapper modelWrapper)
        {
            _modelWrapper = modelWrapper;

            if (Validation())
            {
                Setup();
                Operation();
            }
        }

        private bool Validation()
        {
            Cart cart = _database.GetActiveCart(_modelWrapper.ClientId);
            Product product = _database.GetProductForValidation(_modelWrapper.ProductId);

            if (product != null && cart != null)
            {
                _modelWrapper.CartId = cart.Id;
                return true;
            }

            return false;
        }

        private void Setup() 
        {
            _modelWrapper.Model = _database.GetCartItem(_modelWrapper.CartId, _modelWrapper.ProductId);
        }
    }
}

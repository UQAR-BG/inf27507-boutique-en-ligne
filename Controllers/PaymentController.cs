using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IDatabaseAdapter _database;
        private readonly IAuthentificationAdapter _authService;

        private Cart? _activeCart;
        private int? _clientId;

        public PaymentController(IDatabaseAdapter database, IAuthentificationAdapter authService)
        {
            _database = database;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult PaymentPage()
        {
            if (!CheckIfClientCanCheckout())
                return RedirectToAction("Index", "Home");

            ViewBag.Methods = _database.GetPaymentMethods();

            return View();
        }

        [HttpPost]
        public IActionResult CompleteOrder(PaymentMethod method)
        {
            if (!CheckIfClientCanCheckout())
                return RedirectToAction("Index", "Home");

            Client client = _database.GetClient((int)_clientId);
            double cartTotal = _database.GetCartTotal(_activeCart.Id);

            if (client.Balance < cartTotal)
                return RedirectToAction("NotEnoughBalance");

            _database.UpdateClientBalance(client, cartTotal);
            _database.CreateOrder(client.Id, method);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult NotEnoughBalance()
        {
            return View();
        }

        private bool CheckIfClientCanCheckout()
        {
            _clientId = _authService.GetClientIdIfAuthenticated(HttpContext.Session);
            if (_clientId == 0)
                return false;

            _activeCart = _database.GetActiveCart((int)_clientId);
            if (_activeCart == null || _activeCart.Items.Count == 0)
                return false;

            return true;
        }
    }
}

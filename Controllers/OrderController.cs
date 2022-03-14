using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class OrderController : Controller
    {
        private readonly IDatabaseAdapter _database;
        private readonly IAuthentificationAdapter _authService;

        public OrderController(IDatabaseAdapter database, IAuthentificationAdapter authService)
        {
            _database = database;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult OrderPage(int orderId)
        {
            if (!_authService.IsAuthenticated(HttpContext.Session))
                return RedirectToAction("Index", "Home");

            Order order = _database.GetOrder(orderId);

            return View(order);
        }

        [HttpGet]
        public IActionResult ClientOrdersList()
        {
            int clientId = _authService.GetClientIdIfAuthenticated(HttpContext.Session);
            if (clientId == 0)
                return RedirectToAction("Index", "Home");

            Client client = _database.GetClient(clientId);
            List<Order> orders = _database.GetOrders(client);
            
            ViewData.Add("solde", $"{client.Balance:C}");

            if (orders.Count == 0)
                return RedirectToAction("EmptyOrdersList", new { balance = client.Balance });

            return View(orders);
        }

        [HttpGet]
        public IActionResult AddBalance(int? newBalance)
        {
            int clientId = _authService.GetClientIdIfAuthenticated(HttpContext.Session);
            if (clientId == 0)
                return RedirectToAction("Connection", "Client");
            if (newBalance != null && !(newBalance <= 0))
            {
                Client c = _database.GetClient(clientId);
                _database.UpdateClientBalance(c, (double)-newBalance);
            }

            return RedirectToAction("ClientOrdersList");
        }

        [HttpGet]
        public IActionResult SellerOrdersList()
        {
            int sellerId = _authService.GetSellerIdIfAuthenticated(HttpContext.Session);
            if (sellerId == 0)
                return RedirectToAction("Index", "Home");

            Seller seller = _database.GetSeller(sellerId);
            List<Order> orders = _database.GetOrders(seller);

            if (orders.Count == 0)
                return RedirectToAction("EmptyOrdersList");

            return View(orders);
        }

        [HttpGet]
        public IActionResult EmptyOrdersList(double? balance)
        {
            if (balance != null)
                ViewData.Add("solde", $"{balance:C}");

            return View();
        }
    }
}

using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class SellerController : Controller
    {
        private readonly IDatabaseAdapter _database;
        private readonly IAuthentificationAdapter _authService;
        public SellerController(IDatabaseAdapter database, IAuthentificationAdapter authService)
        {
            _database = database;
            _authService = authService;
        }

        public IActionResult ModifierInfo()
        {
            return View();
        }
        public IActionResult Factures()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult GestionProducts()
        {
            return View();
        }
        public IActionResult Statistiques()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Factures(int orderId)
        {
            if (!_authService.IsAuthenticated(HttpContext.Session))
                return RedirectToAction("Index", "Home");

            Order order = _database.GetOrder(orderId);

            return View(order);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            if (seller == null)
                return RedirectToAction("Create");
            _database.AddUser(seller);
            return RedirectToAction("Connection");
        }
    }
}

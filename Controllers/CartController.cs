using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class CartController : Controller
    {
        private readonly IDatabaseAdapter _database;
        private readonly IAuthentificationAdapter _authService;

        public CartController(IDatabaseAdapter database, IAuthentificationAdapter authService)
        {
            _database = database;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult CartPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int id, int itemQuantity)
        {
            if (!_authService.IsAuthenticatedAsClient(HttpContext.Session))
                return RedirectToAction("ProductPage", "Product", id);

            Client client = _database.GetClient((int)HttpContext.Session.GetInt32("UserId"));
            if (client == null)
                return RedirectToAction("ProductPage", "Product", id);

            _database.CreateActiveCartIfNotExist(client.Id);
            _database.AddItem(client.Id, id, itemQuantity);

            return RedirectToAction("CartPage");
        }
    }
}

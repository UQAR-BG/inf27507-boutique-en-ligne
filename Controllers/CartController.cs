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
            int clientId = _authService.GetClientIdIfAuthenticated(HttpContext.Session);
            if (clientId == 0)
                return RedirectToAction("Index", "Home");

            Cart activeCart = _database.GetActiveCart(clientId);
            if (activeCart == null)
                return RedirectToAction("CartEmpty");

            List<CartItem> cartItems = _database.GetCartItems(activeCart.Id);
            if (cartItems.Count == 0)
                return RedirectToAction("CartEmpty");

            ViewBag.CartTotal = _database.GetCartTotal(activeCart.Id);

            return View(cartItems);
        }

        [HttpGet]
        public IActionResult CartEmpty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int id, int itemQuantity)
        {
            int clientId = _authService.GetClientIdIfAuthenticated(HttpContext.Session);
            if (clientId == 0)
                return RedirectToAction("ProductPage", "Product", id);

            _database.CreateActiveCartIfNotExist(clientId);
            _database.AddItem(clientId, id, itemQuantity);

            return RedirectToAction("CartPage");
        }

        [HttpPost]
        public IActionResult Update(int id, int itemQuantity)
        {
            int clientId = _authService.GetClientIdIfAuthenticated(HttpContext.Session);
            if (clientId == 0)
                return RedirectToAction("Index", "Home");

            _database.UpdateItem(clientId, id, itemQuantity);

            return RedirectToAction("CartPage");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            int clientId = _authService.GetClientIdIfAuthenticated(HttpContext.Session);
            if (clientId == 0)
                return RedirectToAction("Index", "Home");

            _database.RemoveItem(clientId, id);

            return RedirectToAction("CartPage");
        }
    }
}

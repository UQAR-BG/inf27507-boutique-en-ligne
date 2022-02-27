using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class CartController : Controller
    {
        private readonly IDatabaseAdapter _database;

        public CartController(IDatabaseAdapter database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult CartPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int Id, int itemQuantity)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            string? UserType = HttpContext.Session.GetString("UserType");

            if (UserId == null || UserType == null || !UserType.Equals("Client"))
                return RedirectToAction("ProductPage", "Product", Id);

            Client client = _database.GetClient((int)UserId);
            if (client == null)
                return RedirectToAction("ProductPage", "Product", Id);

            return RedirectToAction("CartPage");
        }
    }
}

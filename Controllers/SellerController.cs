using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Models.FormData;
using INF27507_Boutique_En_Ligne.Services;
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

        public IActionResult Connection()
        {
            ViewBag.Sellers = _database.GetSellers();

            return View();
        }

        [HttpPost]
        public IActionResult SelectUser(Seller? user = null)
        {
            if (user == null)
                return RedirectToAction("Connection");
            Seller seller = _database.GetSeller(user.Id);
            if (seller == null || seller.Id == 0)
                return RedirectToAction("Connection");
            _authService.SetUser(seller, HttpContext.Session);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Seller? seller)
        {
            if (seller == null)
                return RedirectToAction("Create");
            _database.AddSeller(seller);
            return RedirectToAction("Connection");
        }

        [HttpGet]
        public IActionResult Info()
        {
            if (!_authService.IsAuthenticatedAsSeller(HttpContext.Session))
                return RedirectToAction("Connection");
            Seller seller = _database.GetSeller(_authService.GetSellerIdIfAuthenticated(HttpContext.Session));
            return View(new UserInfo()
            {
                LastName = seller.Lastname,
                Firstname = seller.Firstname,
                Identifiant = seller.Username
            });
        }

        [HttpPost]
        public IActionResult Info(UserInfo si)
        {
            if (!_authService.IsAuthenticatedAsSeller(HttpContext.Session))
                return RedirectToAction("Connection");
            if (ModelState.IsValid)
            {
                ViewData.Add("valid", true);
                Seller seller = _database.GetSeller(_authService.GetSellerIdIfAuthenticated(HttpContext.Session));
                seller.Firstname = si.Firstname;
                seller.Lastname = si.LastName;
                _database.UpdateSellerInfo(seller);
            }
            else
            {
                ViewData.Add("valid", false);
            }
            return View(si);
        }

        [HttpGet]
        public IActionResult Stats()
        {
            Seller seller = _database.GetSeller(_authService.GetSellerIdIfAuthenticated(HttpContext.Session));
            if (seller == null)
                return RedirectToAction("Connection");

            List<CartItem> items = _database.GetCartItems(seller);
            double total = items.Sum(i => i.Quantity * i.SalePrice);
            double profits = total * 0.15;
            int quantity = items.Sum(i => i.Quantity);

            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "total", string.Format("{0:C}", total) },
                { "profits", string.Format("{0:C}", profits) },
                { "quantity", quantity.ToString() }
            };
            return View(data);
        }
    }
}

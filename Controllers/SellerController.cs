using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Models.FormData;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create(Seller seller)
        {
            if (seller == null)
                return RedirectToAction("Create");
            _database.AddSeller(seller);
            return RedirectToAction("Connection");
        }

        public IActionResult Info()
        {
            if (!_authService.IsAuthenticatedAsSeller(HttpContext.Session))
                return RedirectToAction("Connection");
            Seller seller = _database.GetSeller(_authService.GetSellerIdIfAuthenticated(HttpContext.Session));
            return View(new SellerInfo()
            {
                LastName = seller.Lastname,
                Firstname = seller.Firstname,
                Identifiant = seller.Username
            });
        }
        [HttpPost]
        public IActionResult Info(Seller vendeur)
        {
            if (!_authService.IsAuthenticatedAsSeller(HttpContext.Session))
                return RedirectToAction("Connection");
            if (ModelState.IsValid)
            {
                ViewData.Add("valid", true);
                Seller seller = _database.GetSeller(_authService.GetSellerIdIfAuthenticated(HttpContext.Session));
                seller.Firstname = vendeur.Firstname;
                seller.Lastname = vendeur.Lastname;
                _database.UpdateSellerInfo(seller);
            }
            else
            {
                ViewData.Add("valid", false);
            }
            return View(vendeur);
        }

        public IActionResult Statistiques()
        {
            if (!_authService.IsAuthenticatedAsSeller(HttpContext.Session))
                return RedirectToAction("Connection");
            Seller seller = _database.GetSeller(_authService.GetSellerIdIfAuthenticated(HttpContext.Session));
            List<Order> orders = _database.GetOrders(seller);
            Dictionary<string, string> data = new Dictionary<string, string>
        {
            {"total", orders.Sum(o => o.Cart.Items.Sum(i=>i.Quantity*i.SalePrice)).ToString("F", CultureInfo.CreateSpecificCulture("fr-FR"))},
            {"art", orders.Sum(o => o.Cart.Items.Sum(i => i.Quantity)).ToString("N0", CultureInfo.CreateSpecificCulture("fr-FR"))}
        };
            return View(data);
        }


    }
}


using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDatabaseAdapter _database;
        private readonly IAuthentificationAdapter _authService;

        public ProductController(IDatabaseAdapter database, IAuthentificationAdapter authService)
        {
            _database = database;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult ProductPage(int id)
        {
            Product product = _database.GetProduct(id);
            if (product == null || !product.Active)
                return RedirectToAction("NotFound");

            return View(product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!_authService.IsAuthenticatedAsSeller(HttpContext.Session))
                return RedirectToAction("Index", "Home");

            PrepareViewBagToFillProductInfo();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!_authService.IsAuthenticatedAsSeller(HttpContext.Session))
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                PrepareViewBagToFillProductInfo();
                return View();
            }

            product.ImageURL = "";
            product = _database.AddProduct(product);

            return RedirectToAction("ProductPage", new { id = product.Id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!CanManageProduct(id))
                return RedirectToAction("Index", "Home");

            ViewBag.Product = _database.GetProduct(id);

            return View();
        }

        [HttpPost]
        public IActionResult Edit(ProductUpdate product)
        {
            if (!CanManageProduct(product.Id))
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                ViewData.Add("valid", true);
                ViewBag.Product = _database.UpdateProduct(product);
            }
            else
            {
                ViewData.Add("valid", false);
                ViewBag.Product = _database.GetProduct(product.Id);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!CanManageProduct(id))
                return RedirectToAction("Index", "Home");

            _database.DeleteProduct(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult NotFound()
        {
            return View();
        }

        private bool CanManageProduct(int productId)
        {
            bool canManage = true;

            int sellerId = _authService.GetSellerIdIfAuthenticated(HttpContext.Session);
            if (sellerId == 0)
                canManage = false;

            if (!_database.ProductIsOwnedBy(productId, sellerId))
                canManage = false;

            return canManage;
        }

        private void PrepareViewBagToFillProductInfo()
        {
            ViewBag.Genders = _database.GetGenders();
            ViewBag.Usages = _database.GetUsages();
            ViewBag.Colours = _database.GetColours();
            ViewBag.Categories = _database.GetCategories();
            ViewBag.SubCategories = _database.GetSubCategories();
            ViewBag.ProductTypes = _database.GetProductTypes();
        }
    }
}

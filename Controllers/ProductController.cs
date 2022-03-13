using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDatabaseAdapter _database;

        public ProductController(IDatabaseAdapter database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult ProductPage(int id)
        {
            Product product = _database.GetProduct(id);
            if (product == null)
                return RedirectToAction("NotFound");

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Product = _database.GetProduct(id);

            return View();
        }

        [HttpPost]
        public IActionResult Edit(ProductUpdate product)
        {
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

        [HttpGet]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}

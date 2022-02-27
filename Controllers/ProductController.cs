using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services.Database;
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
        public IActionResult NotFound()
        {
            return View();
        }
    }
}

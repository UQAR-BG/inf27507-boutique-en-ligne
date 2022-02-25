using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using INF27507_Boutique_En_Ligne.Services.Database;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabaseAdapter _database;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _database = ServicesFactory.getInstance().GetDatabaseService();
        }

        public IActionResult Index()
        {
            List<Product> products = _database.GetProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace INF27507_Boutique_En_Ligne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabaseAdapter _database;
        private readonly IAuthentificationAdapter _authService;

        public HomeController(ILogger<HomeController> logger, IDatabaseAdapter database, IAuthentificationAdapter authService)
        {
            _logger = logger;
            _database = database;
            _authService = authService;
        }

        public IActionResult Index()
        {
            _authService.SetDefaultUser(HttpContext.Session);

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
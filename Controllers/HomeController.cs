using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using INF27507_Boutique_En_Ligne.Models.FormData;

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

        public IActionResult Index(Filter? filter, string search)
        {
            _authService.SetDefaultUser(HttpContext.Session);

            List<Product> products = _database.GetProducts();
            ViewData.Add("Search", search);
            ViewBag.cat = _database.GetCategories();
            ViewBag.FilterForm = new Filter()
                {
                    CategoryID = 0,
                    Genders = _database.GetGenders().ToDictionary(gender => gender, m => true),
                    GendersBools = _database.GetGenders().ToDictionary(gender => gender.Id, m => true),
                    Min = (int)Math.Round(products.Min(p => p.Price), 0, MidpointRounding.ToPositiveInfinity),
                    Max = (int)Math.Round(products.Max(p => p.Price), 0, MidpointRounding.ToPositiveInfinity),
                    Price = filter?.Price ?? 0
                };
            return View(products.Where(p => (filter is not {CategoryID: { }} || (p.Category.Id == filter?.CategoryID || filter?.CategoryID == 0) 
                && ((filter.GendersBools == null)|| filter.GendersBools.GetValueOrDefault(p.GenderId, false)) 
                && (filter.Price == 0 || p.Price <= filter.Price))
                && search == null || (search != null && p.Title.Contains(search))).ToList());
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
using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Models.FormData;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace INF27507_Boutique_En_Ligne.Controllers;

public class ClientController : Controller
{
    private readonly IDatabaseAdapter _database;
    private readonly IAuthentificationAdapter _authService;
    

    public ClientController(IDatabaseAdapter database, IAuthentificationAdapter authService)
    {
        _database = database;
        _authService = authService;
    }

    public IActionResult Connection()
    {
        ViewBag.Clients = _database.GetClients();
        
        return View();
    }
    
    [HttpPost]
    public IActionResult SelectUser(Client? user = null)
    {
        if(user == null)
            return RedirectToAction("Connection");
        Client client = _database.GetClient(user.Id);
        if (client == null || client.Id == 0)
            return RedirectToAction("Connection");
        _authService.SetUser(client, HttpContext.Session);
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Client client)
    {
        if (client == null)
            return RedirectToAction("Create");
        _database.AddClient(client);
        return RedirectToAction("Connection");
    }

    public IActionResult Info()
    {
        if (!_authService.IsAuthenticatedAsClient(HttpContext.Session))
            return RedirectToAction("Connection");
        Client client = _database.GetClient(_authService.GetClientIdIfAuthenticated(HttpContext.Session));
        return View(new ClientInfo()
        {
            LastName = client.Lastname,
            Firstname = client.Firstname,
            Identifiant = client.Username
        });
    }

    [HttpPost]
    public IActionResult Info(ClientInfo ci)
    {
        if (!_authService.IsAuthenticatedAsClient(HttpContext.Session))
            return RedirectToAction("Connection");
        if (ModelState.IsValid)
        {
            ViewData.Add("valid", true);
            Client client = _database.GetClient(_authService.GetClientIdIfAuthenticated(HttpContext.Session));
            client.Firstname = ci.Firstname;
            client.Lastname = ci.LastName;
            _database.UpdateClientInfo(client);
        }
        else
        {
            ViewData.Add("valid", false);
        }
        return View(ci);
    }
}
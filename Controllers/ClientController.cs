using INF27507_Boutique_En_Ligne.Models;
using INF27507_Boutique_En_Ligne.Services;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult SelectUser(Client user)
    {
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
}

using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BlogicCRM.Controllers;

public class ClientsController(ClientRepository repository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var clients = await repository.GetAllClientsAsync();
        return View(clients);
    }
    
}
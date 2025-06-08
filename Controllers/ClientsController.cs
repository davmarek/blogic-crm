
using BlogicCRM.Models;
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
    
    public async Task<IActionResult> Show(Guid id)
    {
        var consultant = await repository.GetClientByIdAsync(id);
        if (consultant is null)
        {
            return NotFound();
        }
        
        return View(consultant);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        if (!ModelState.IsValid)
        {
            return View(client);
        }
        
        await repository.AddClientAsync(client);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var client = await repository.GetClientByIdAsync(id);
        if (client is null)
        {
            return NotFound();
        }

        await repository.DeleteClientAsync(client);
        return RedirectToAction(nameof(Index));
    }
    
}
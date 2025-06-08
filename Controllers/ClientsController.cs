using System.Text;
using BlogicCRM.Models;
using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Text.Encoding;


namespace BlogicCRM.Controllers;

public class ClientsController(ClientRepository repository) : Controller
{
    private const int PageSize = 10;

    public async Task<IActionResult> Index(
        int? pageNumber
    )
    {
        var clients = repository.GetAllClientsQueryable();

        return View(
            await PaginatedList<Client>.CreateAsync(clients, pageIndex: pageNumber ?? 1, pageSize: PageSize)
        );
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
        if (client.Birthdate > DateTime.Now)
        {
            ModelState.AddModelError("Birthdate", "Birthdate cannot be in the future.");
        }

        if (!ModelState.IsValid || ModelState.ErrorCount > 0)
        {
            return View(client);
        }

        await repository.AddClientAsync(client);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(Guid id)
    {
        var client = await repository.GetClientByIdAsync(id);
        if (client is null)
        {
            return NotFound();
        }

        return View(client);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Client client)
    {
        if (client.Id == Guid.Empty)
        {
            return BadRequest("Missing contract ID.");
        }

        if (client.Birthdate > DateTime.Now)
        {
            ModelState.AddModelError("Birthdate", "Birthdate cannot be in the future.");
        }

        if (!ModelState.IsValid || ModelState.ErrorCount > 0)
        {
            return View(client);
        }

        var existingClient = await repository.GetClientByIdAsync(client.Id);
        if (existingClient == null)
        {
            return NotFound();
        }

        existingClient.FirstName = client.FirstName;
        existingClient.LastName = client.LastName;
        existingClient.Email = client.Email;
        existingClient.Phone = client.Phone;
        existingClient.BirthNumber = client.BirthNumber;
        existingClient.Birthdate = client.Birthdate;

        await repository.UpdateClientAsync(existingClient);
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

    [HttpPost]
    public async Task<IActionResult> ExportToCsv()
    {
        var clients = await repository.GetAllClientsAsync();
        
        var content = CsvHelper.BuildCsv(clients,
            "Id,FirstName,LastName,Email,Phone,BirthNumber,Birthdate",
            client =>
                $"{client.Id},{client.FirstName},{client.LastName},{client.Email},{client.Phone},{client.BirthNumber},{client.Birthdate:yyyy-MM-dd}"
        );
        
        return File(UTF8.GetBytes(content), "text/csv", "clients.csv");
    }
}
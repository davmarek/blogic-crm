using BlogicCRM.Models.ViewModels;
using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogicCRM.Controllers;

[Route("[controller]")]
public class SearchController(
    ContractRepository contractRepository,
    ClientRepository clientRepository,
    ConsultantRepository consultantRepository
) : Controller
{
    [Route("")]
    public async Task<IActionResult> Index([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return RedirectToAction("Index", "Home");
        }

        ViewData["PreviousSearchQuery"] = query;

        var clients = await clientRepository.SearchClientsAsync(query);
        var contracts = await contractRepository.SearchContractsAsync(query);
        var consultants = await consultantRepository.SearchConsultantsAsync(query);

        return View(new SearchViewModel
        {
            SearchTerm = query,
            Clients = clients,
            Contracts = contracts,
            Consultants = consultants
        });
    }
}
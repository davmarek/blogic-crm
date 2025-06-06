using BlogicCRM.Models;
using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BlogicCRM.Controllers;

public class ContractsController(ContractRepository repository) : Controller
{
    private const int PageSize = 10;
    
    public async Task<IActionResult> Index(
        int? pageNumber
    )
    {
        var contracts = repository.GetAllContractsQueryable();
        return View(await PaginatedList<Contract>.CreateAsync(contracts, pageIndex: pageNumber ?? 1, pageSize: PageSize));
    }

    public async Task<IActionResult> Show(Guid id)
    {
        var contracts = await repository.GetContractByIdAsync(id);
        if (contracts is null)
        {
            return NotFound();
        }

        return View(contracts);
    }
}
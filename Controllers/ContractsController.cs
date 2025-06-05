
using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BlogicCRM.Controllers;

public class ContractsController(ContractRepository repository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var contracts = await repository.GetAllContractsAsync();
        return View(contracts);
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
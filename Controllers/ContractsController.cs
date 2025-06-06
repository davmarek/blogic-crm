using BlogicCRM.Models;
using BlogicCRM.Models.ViewModels;
using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BlogicCRM.Controllers;

public class ContractsController(
    ContractRepository contractRepository,
    ClientRepository clientRepository,
    ConsultantRepository consultantRepository,
    InstitutionRepository institutionRepository,
    ILogger<ContractsController> logger
) : Controller
{
    private const int PageSize = 10;

    public async Task<IActionResult> Index(
        int? pageNumber
    )
    {
        var contracts = contractRepository.GetAllContractsQueryable();
        return View(
            await PaginatedList<Contract>.CreateAsync(contracts, pageIndex: pageNumber ?? 1, pageSize: PageSize));
    }

    public async Task<IActionResult> Show(Guid id)
    {
        var contracts = await contractRepository.GetContractByIdAsync(id);
        if (contracts is null)
        {
            return NotFound();
        }

        return View(contracts);
    }

    public async Task<IActionResult> Create()
    {
        return View(new ContractCreateViewModel
        {
            Institutions = await institutionRepository.GetAllInstitutionsAsync(),
            Clients = await clientRepository.GetAllClientsAsync(),
            Consultants = await consultantRepository.GetAllConsultantsAsync()
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContractCreateViewModel model)
    {
        logger.LogInformation("InstitutionId: {}",model.InstitutionId);
        logger.LogInformation(model.ClientId.ToString());
        logger.LogInformation(model.AdminId.ToString());

        if (!ModelState.IsValid)
        {
            model.Institutions = await institutionRepository.GetAllInstitutionsAsync();
            model.Clients = await clientRepository.GetAllClientsAsync();
            model.Consultants = await consultantRepository.GetAllConsultantsAsync();
            return View(model);
        }

        var contract = new Contract
        {
            ClientId = model.ClientId,
            AdminId = model.AdminId,
            InstitutionId = model.InstitutionId,
            Created = model.CreatedDate,
            Effective = model.EffectiveDate,
            Closed = model.ClosingDate
        };

        await contractRepository.AddInstitutionAsync(contract);
        return RedirectToAction(nameof(Index));
    }
}
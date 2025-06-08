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
        var contract = await contractRepository.GetContractByIdAsync(id);
        if (contract is null)
        {
            return NotFound();
        }

        return View(contract);
    }

    public async Task<IActionResult> Create()
    {
        return View(new ContractFormViewModel
        {
            Institutions = await institutionRepository.GetAllInstitutionsAsync(),
            Clients = await clientRepository.GetAllClientsAsync(),
            Consultants = await consultantRepository.GetAllConsultantsAsync()
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContractFormViewModel model)
    {
        logger.LogInformation("Selected consultant count {C}", model.ConsultantIds.Count);
        foreach (var modelConsultantId in model.ConsultantIds)
        {
            logger.LogInformation("Adding consultant {S}", modelConsultantId.ToString());
        }
        
        if (model.EffectiveDate < model.CreatedDate)
        {
            ModelState.AddModelError(nameof(model.EffectiveDate), "Effective date cannot be before the created date.");
        }

        if (model.ClosingDate < model.CreatedDate)
        {
            ModelState.AddModelError(nameof(model.ClosingDate), "Closing date cannot be before the created date.");
        }

        if (model.ClosingDate < model.EffectiveDate)
        {
            ModelState.AddModelError(nameof(model.ClosingDate), "Closing date cannot be before the effective date.");
        }

        if (model.ConsultantIds.Contains(model.AdminId))
        {
            ModelState.AddModelError(nameof(model.ConsultantIds), "Admin cannot be a consultant.");
        }
        
        if (!ModelState.IsValid || ModelState.ErrorCount > 0)
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
        

        await contractRepository.AddContractAsync(contract, model.ConsultantIds);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var contract = await contractRepository.GetContractByIdAsync(id);
        if (contract is null)
        {
            return NotFound();
        }
        
        return View(new ContractFormViewModel
        {
            ClientId = contract.ClientId,
            AdminId = contract.AdminId,
            InstitutionId = contract.InstitutionId,
            CreatedDate = contract.Created,
            EffectiveDate = contract.Effective,
            ClosingDate = contract.Closed,
            ConsultantIds = contract.Consultants.Select(c => c.Id).ToList(),
            
            Institutions = await institutionRepository.GetAllInstitutionsAsync(),
            Clients = await clientRepository.GetAllClientsAsync(),
            Consultants = await consultantRepository.GetAllConsultantsAsync()
        });
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(ContractFormViewModel model)
    {
        if (model.Id == Guid.Empty)
        {
            return BadRequest("Missing contract ID.");
        }
        
        logger.LogInformation("Selected consultant count {C}", model.ConsultantIds.Count);
        foreach (var modelConsultantId in model.ConsultantIds)
        {
            logger.LogInformation("Adding consultant {S}", modelConsultantId.ToString());
        }
        
        if (model.EffectiveDate < model.CreatedDate)
        {
            ModelState.AddModelError(nameof(model.EffectiveDate), "Effective date cannot be before the created date.");
        }

        if (model.ClosingDate < model.CreatedDate)
        {
            ModelState.AddModelError(nameof(model.ClosingDate), "Closing date cannot be before the created date.");
        }

        if (model.ClosingDate < model.EffectiveDate)
        {
            ModelState.AddModelError(nameof(model.ClosingDate), "Closing date cannot be before the effective date.");
        }

        if (model.ConsultantIds.Contains(model.AdminId))
        {
            ModelState.AddModelError(nameof(model.ConsultantIds), "Admin cannot be a consultant.");
        }
        
        if (!ModelState.IsValid || ModelState.ErrorCount > 0)
        {
            model.Institutions = await institutionRepository.GetAllInstitutionsAsync();
            model.Clients = await clientRepository.GetAllClientsAsync();
            model.Consultants = await consultantRepository.GetAllConsultantsAsync();
            return View(model);
        }
        
        var existingContract = await contractRepository.GetContractByIdAsync(model.Id);
        if (existingContract == null)
        {
            return NotFound();
        }
        
        existingContract.ClientId = model.ClientId;
        existingContract.AdminId = model.AdminId;
        existingContract.InstitutionId = model.InstitutionId;
        existingContract.Created = model.CreatedDate;
        existingContract.Effective = model.EffectiveDate;
        existingContract.Closed = model.ClosingDate;
        

        await contractRepository.UpdateContractAsync(existingContract, model.ConsultantIds);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var contract = await contractRepository.GetContractByIdAsync(id);
        if (contract is null)
        {
            return NotFound();
        }

        await contractRepository.DeleteContractAsync(contract);
        return RedirectToAction(nameof(Index));
    }
}

using BlogicCRM.Models;
using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BlogicCRM.Controllers;

public class ConsultantsController(ConsultantRepository repository) : Controller
{
    private const int PageSize = 10;
    
    public async Task<IActionResult> Index(
        int? pageNumber
    )
    {
        var consultants = repository.GetAllConsultantsQueryable();

        return View(
            await PaginatedList<Consultant>.CreateAsync(consultants, pageIndex: pageNumber ?? 1, pageSize: PageSize)
        );
    }
    
    public async Task<IActionResult> Show(Guid id)
    {
        var consultant = await repository.GetConsultantByIdAsync(id);
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
    public async Task<IActionResult> Create(Consultant consultant)
    {
        if (consultant.Birthdate > DateTime.Now)
        {
            ModelState.AddModelError("Birthdate", "Birthdate cannot be in the future.");
        }
        if (!ModelState.IsValid || ModelState.ErrorCount > 0)
        {
            return View(consultant);
        }
        
        await repository.AddConsultantAsync(consultant);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(Guid id)
    {
        var consultant = await repository.GetConsultantByIdAsync(id);
        if (consultant is null)
        {
            return NotFound();
        }
        
        return View(consultant);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Consultant consultant)
    {
        if (consultant.Id == Guid.Empty)
        {
            return BadRequest("Missing contract ID.");
        }
        
        if (consultant.Birthdate > DateTime.Now)
        {
            ModelState.AddModelError("Birthdate", "Birthdate cannot be in the future.");
        }
        if (!ModelState.IsValid || ModelState.ErrorCount > 0)
        {
            return View(consultant);
        }
        
        var existingConsultant = await repository.GetConsultantByIdAsync(consultant.Id);
        if (existingConsultant == null)
        {
            return NotFound();
        }
        
        existingConsultant.FirstName = consultant.FirstName;
        existingConsultant.LastName = consultant.LastName;
        existingConsultant.Email = consultant.Email;
        existingConsultant.Phone = consultant.Phone;
        existingConsultant.BirthNumber = consultant.BirthNumber;
        existingConsultant.Birthdate = consultant.Birthdate;

        await repository.UpdateConsultantAsync(existingConsultant);
        return RedirectToAction(nameof(Show), new { id = existingConsultant.Id });
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var consultant = await repository.GetConsultantByIdAsync(id);
        if (consultant is null)
        {
            return NotFound();
        }

        await repository.DeleteConsultantAsync(consultant);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public async Task<IActionResult> ExportToCsv()
    {
        var consultants = await repository.GetAllConsultantsAsync();
        
        var content = CsvHelper.BuildCsv(consultants,
            "Id,FirstName,LastName,Email,Phone,BirthNumber,Birthdate",
            c =>
                $"{c.Id},{c.FirstName},{c.LastName},{c.Email},{c.Phone},{c.BirthNumber},{c.Birthdate:yyyy-MM-dd}"
        );
        
        return File(System.Text.Encoding.UTF8.GetBytes(content), "text/csv", "consultants.csv");
    }
    
}
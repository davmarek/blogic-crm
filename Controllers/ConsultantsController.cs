
using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BlogicCRM.Controllers;

public class ConsultantsController(ConsultantRepository repository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await repository.GetAllConsultantsAsync();
        return View(items);
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
    
}
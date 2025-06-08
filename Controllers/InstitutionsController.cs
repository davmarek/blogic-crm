using BlogicCRM.Models;
using BlogicCRM.Models.ViewModels;
using BlogicCRM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogicCRM.Controllers;

public class InstitutionsController(InstitutionRepository repository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var institutions = await repository.GetAllInstitutionsAsync();
        return View(new InstitutionIndexViewModel
        {
            Institutions = institutions
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(InstitutionIndexViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", new InstitutionIndexViewModel
            {
                Institutions = await repository.GetAllInstitutionsAsync(),
                NewInstitutionName = viewModel.NewInstitutionName
            });
        }

        await repository.AddInstitutionAsync(new Institution { Name = viewModel.NewInstitutionName });
        return RedirectToAction(nameof(Index));
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var institution = await repository.GetInstitutionByIdAsync(id);
        if (institution == null)
        {
            return NotFound();
        }

        await repository.DeleteInstitutionAsync(institution);
        return RedirectToAction(nameof(Index));
    }
}
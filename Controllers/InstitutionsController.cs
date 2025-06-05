using BlogicCRM.Data;
using BlogicCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Controllers;

public class InstitutionsController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<InstitutionsController> _logger;

    public InstitutionsController(AppDbContext context, ILogger<InstitutionsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var institutions = _context.Institutions.ToList();
        return View(new InstitutionIndexViewModel
        {
            Institutions = institutions
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(InstitutionIndexViewModel viewModel)
    {
        _logger.LogInformation("Storing new institution: {Name}", viewModel.NewInstitutionName);
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Model state is invalid for institution: {Name}", viewModel.NewInstitutionName);
            // log the errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                _logger.LogError("Model state error: {ErrorMessage}", error.ErrorMessage);
            }
            
            return View("Index", new InstitutionIndexViewModel
            {
                Institutions = _context.Institutions.ToList(),
                NewInstitutionName = viewModel.NewInstitutionName
            });
        }
        

        _context.Institutions.Add(new Institution { Name = viewModel.NewInstitutionName! });
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
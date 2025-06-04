using BlogicCRM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Controllers;

public class InstitutionsController : Controller
{
    private readonly AppDbContext _context;

    public InstitutionsController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var institutions = _context.Institutions.ToList();
        return View(institutions);
    }
}
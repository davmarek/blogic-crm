using BlogicCRM.Database;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class InstitutionRepository(AppDbContext context)
{
    public async Task<IEnumerable<Institution>> GetAllInstitutionsAsync()
    {
        return await context.Institutions.AsNoTracking().ToListAsync();
    }

    public async Task<Institution?> GetInstitutionByIdAsync(int id)
    {
        return await context.Institutions.FindAsync(id);
    }

    public async Task AddInstitutionAsync(Institution institution)
    {
        context.Institutions.Add(institution);
        await context.SaveChangesAsync();
    }

    public async Task UpdateInstitutionAsync(Institution institution)
    {
        context.Institutions.Update(institution);
        await context.SaveChangesAsync();
    }

    public async Task DeleteInstitutionAsync(Institution institution)
    {
        context.Institutions.Remove(institution);
        await context.SaveChangesAsync();
    }
}
using BlogicCRM.Database;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class ConsultantRepository(AppDbContext context)
{
    public async Task<IEnumerable<Consultant>> GetAllConsultantsAsync()
    {
        return await context.Consultants.AsNoTracking().ToListAsync();
    }

    public async Task<Consultant?> GetConsultantByIdAsync(Guid id)
    {
        return await context.Consultants.FindAsync(id);
    }

    public async Task AddInstitutionAsync(Institution institution)
    {
        // TODO: Implement for Client
        context.Institutions.Add(institution);
        await context.SaveChangesAsync();
    }

    public async Task UpdateInstitutionAsync(Institution institution)
    {
        // TODO: Implement for Client
        context.Institutions.Update(institution);
        await context.SaveChangesAsync();
    }

    public async Task DeleteInstitutionAsync(Guid id)
    {
        // TODO: Implement for Client
        var institution = await GetConsultantByIdAsync(id);
        if (institution != null)
        {
            context.Consultants.Remove(institution);
            await context.SaveChangesAsync();
        }
    }
}
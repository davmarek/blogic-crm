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
        return await context.Consultants
            .Include(e => e.AdministeredContracts)
            .Include(e => e.ParticipatingContracts)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddInstitutionAsync(Institution institution)
    {
        // TODO: Implement for Consultant
        context.Institutions.Add(institution);
        await context.SaveChangesAsync();
    }

    public async Task UpdateInstitutionAsync(Institution institution)
    {
        // TODO: Implement for Consultant
        context.Institutions.Update(institution);
        await context.SaveChangesAsync();
    }

    public async Task DeleteConsultantAsync(Consultant consultant)
    {
        context.Consultants.Remove(consultant);
        await context.SaveChangesAsync();
    }
}
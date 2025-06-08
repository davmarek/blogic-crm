using BlogicCRM.Database;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class ConsultantRepository(AppDbContext context)
{
    public async Task<IEnumerable<Consultant>> GetAllConsultantsAsync()
    {
        return await context.Consultants
            .AsNoTracking()
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();
    }

    public IQueryable<Consultant> GetAllConsultantsQueryable()
    {
        return context.Consultants
            .OrderByDescending(e => e.CreatedAt)
            .AsNoTracking();
    }

    public async Task<Consultant?> GetConsultantByIdAsync(Guid id)
    {
        return await context.Consultants
            .Include(e => e.AdministeredContracts)
            .Include(e => e.ParticipatingContracts)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddConsultantAsync(Consultant consultant)
    {
        context.Consultants.Add(consultant);
        await context.SaveChangesAsync();
    }

    public async Task UpdateConsultantAsync(Consultant consultant)
    {
        context.Consultants.Update(consultant);
        await context.SaveChangesAsync();
    }

    public async Task DeleteConsultantAsync(Consultant consultant)
    {
        context.Consultants.Remove(consultant);
        await context.SaveChangesAsync();
    }
}
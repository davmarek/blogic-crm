using BlogicCRM.Data;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class ClientRepository(AppDbContext context)
{
    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await context.Clients.AsNoTracking().ToListAsync();
    }

    public async Task<Institution?> GetInstitutionByIdAsync(int id)
    {
        // TODO: Implement for Client
        return await context.Institutions.FindAsync(id);
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

    public async Task DeleteInstitutionAsync(int id)
    {
        // TODO: Implement for Client
        var institution = await GetInstitutionByIdAsync(id);
        if (institution != null)
        {
            context.Institutions.Remove(institution);
            await context.SaveChangesAsync();
        }
    }
}
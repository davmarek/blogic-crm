using BlogicCRM.Database;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class ClientRepository(AppDbContext context)
{
    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await context.Clients.AsNoTracking().ToListAsync();
    }

    public async Task<Client?> GetClientByIdAsync(Guid id)
    {
        return await context.Clients
            .Include(e => e.Contracts)
            .FirstOrDefaultAsync(e => e.Id == id);
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
        var client = await GetClientByIdAsync(id);
        if (client != null)
        {
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
        }
    }
}
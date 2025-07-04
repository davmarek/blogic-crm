using BlogicCRM.Database;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class ClientRepository(AppDbContext context)
{
    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await context.Clients
            .AsNoTracking()
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();
    }

    public IQueryable<Client> GetAllClientsQueryable()
    {
        return context.Clients
            .OrderByDescending(e => e.CreatedAt)
            .AsNoTracking();
    }

    public async Task<Client?> GetClientByIdAsync(Guid id)
    {
        return await context.Clients
            .Include(e => e.Contracts)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddClientAsync(Client client)
    {
        context.Clients.Add(client);
        await context.SaveChangesAsync();
    }

    public async Task UpdateClientAsync(Client client)
    {
        context.Clients.Update(client);
        await context.SaveChangesAsync();
    }

    public async Task DeleteClientAsync(Client client)
    {
        context.Clients.Remove(client);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Client>> SearchClientsAsync(string query)
    {
        // query = query.ToLower();
        return await context.Clients
            .Where(c =>
                c.Id.ToString().Contains(query) ||
                EF.Functions.Like(c.FirstName, $"%{query}%") ||
                EF.Functions.Like(c.LastName, $"%{query}%") ||
                EF.Functions.Like(c.Email, $"%{query}%")
            )
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();
    }
}
using BlogicCRM.Database;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class ContractRepository(
    AppDbContext context,
    ILogger<ContractRepository> logger
)
{
    public IQueryable<Contract> GetAllContractsQueryable()
    {
        return context.Contracts
            .Include(c => c.Client)
            .Include(c => c.Admin)
            .Include(c => c.Institution)
            .Include(c => c.Consultants)
            .OrderByDescending(e => e.CreatedAt)
            .AsNoTracking();
    }

    public async Task<Contract?> GetContractByIdAsync(Guid id)
    {
        return await context.Contracts
            .Include(c => c.Client)
            .Include(c => c.Institution)
            .Include(c => c.Admin)
            .Include(c => c.Consultants)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddContractAsync(Contract contract, IEnumerable<Guid>? consultantIds = null)
    {
        if (consultantIds != null)
        {
            var consultants = await context.Consultants
                .Where(e => consultantIds.Contains(e.Id) && e.Id != contract.Id)
                .ToListAsync();

            contract.Consultants = consultants;
        }

        context.Contracts.Add(contract);

        await context.SaveChangesAsync();
    }

    public async Task UpdateContractAsync(Contract contract, IEnumerable<Guid>? consultantIds = null)
    {
        logger.LogInformation("Updating contract {ContractId}", contract.Id);
        if (consultantIds != null)
        {
            var newConsultants = await context.Consultants
                .Where(e => consultantIds.Contains(e.Id) && e.Id != contract.Id)
                .ToListAsync();

            contract.Consultants.Clear();

            foreach (var newConsultant in newConsultants)
            {
                contract.Consultants.Add(newConsultant);
            }
        }

        context.Contracts.Update(contract);
        await context.SaveChangesAsync();
    }

    public async Task DeleteContractAsync(Contract contract)
    {
        context.Contracts.Remove(contract);
        await context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Contract>> SearchContractsAsync(string query)
    {
        // query = query.ToLower();
        return await context.Contracts
            .Include(c => c.Client)
            .Include(c => c.Institution)
            .Include(c => c.Admin)
            .Include(c => c.Consultants)
            .Where(c =>
                c.Id.ToString().Contains(query) ||
                EF.Functions.Like(c.Client.FirstName, $"%{query}%") ||
                EF.Functions.Like(c.Client.LastName, $"%{query}%") ||
                EF.Functions.Like(c.Admin.FirstName, $"%{query}%") ||
                EF.Functions.Like(c.Admin.LastName, $"%{query}%") ||
                EF.Functions.Like(c.Institution.Name, $"%{query}%")
            )
            .ToListAsync();
    }
}
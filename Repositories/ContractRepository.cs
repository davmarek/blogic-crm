using BlogicCRM.Database;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class ContractRepository(AppDbContext context)
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

    public async Task UpdateContractAsync(Contract contract)
    {
        context.Contracts.Update(contract);
        await context.SaveChangesAsync();
    }

    public async Task DeleteContractAsync(Guid id)
    {
        var institution = await GetContractByIdAsync(id);
        if (institution != null)
        {
            context.Contracts.Remove(institution);
            await context.SaveChangesAsync();
        }
    }
}
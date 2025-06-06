using BlogicCRM.Data;
using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Repositories;

public class ContractRepository(AppDbContext context)
{
    public async Task<IEnumerable<Contract>> GetAllContractsAsync()
    {
        return await context.Contracts
            .Include(c => c.Client)
            .Include(c => c.Institution)
            .AsNoTracking()
            .ToListAsync();
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

    public async Task AddInstitutionAsync(Contract contract)
    {
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
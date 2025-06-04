using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Institution>(b =>
        {
            b.HasMany(i => i.Contracts)
                .WithOne(c => c.Institution)
                .HasForeignKey(c => c.InstitutionId)
                .IsRequired();

            b.HasData(
                new Institution { Id = 1, Name = "ČSOB" },
                new Institution { Id = 2, Name = "AEGON" },
                new Institution { Id = 3, Name = "AXA" }
            );
        });


        modelBuilder.Entity<Client>(b =>
        {
            b.HasMany(i => i.Contracts)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientId)
                .IsRequired();
            b.HasData(
                new Client
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), FirstName = "Jan", LastName = "Novák", Email = "novak@mail.cz", Phone = "123456789"
                },
                new Client
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), FirstName = "David", LastName = "Marek", Email = "david@gmail.com", Phone = "123456789"
                }
            );
        });
    }
}
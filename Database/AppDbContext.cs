using BlogicCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogicCRM.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Consultant> Consultants { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Institution>(b =>
        {
            b.HasData(
                new Institution { Id = 1, Name = "ČSOB" },
                new Institution { Id = 2, Name = "AEGON" },
                new Institution { Id = 3, Name = "AXA" }
            );
        });


        modelBuilder.Entity<Client>(b =>
        {
            var clients = new List<Client>();

            for (var i = 0; i < 10; i++)
            {
                clients.Add(new Client
                    {
                        Id = Faker.GetGuid(i),
                        FirstName = Faker.GetFirstName(i),
                        LastName = Faker.GetLastName(i),
                        Email = Faker.GetEmail(i),
                        Phone = Faker.GetPhoneNumber(i),
                        BirthNumber = "1234567890",
                        Birthdate = DateTime.Today.AddYears(-40 + i),
                        CreatedAt = new DateTime(2025, 6, 7, 11, 0, 0),
                    }
                );
            }

            b.HasData(clients);
        });

        modelBuilder.Entity<Consultant>(b =>
        {
            b.HasMany(e => e.ParticipatingContracts)
                .WithMany(e => e.Consultants)
                .UsingEntity("ContractConsultant");

            var consultants = new List<Consultant>();

            for (var i = 0; i < 10; i++)
            {
                consultants.Add(new Consultant
                    {
                        Id = Faker.GetGuid(i),
                        FirstName = Faker.GetFirstName(15 - i),
                        LastName = Faker.GetLastName(15 - i),
                        Email = Faker.GetEmail(15 - i),
                        Phone = Faker.GetPhoneNumber(15 - i),
                        BirthNumber = "1234567890",
                        Birthdate = DateTime.Today.AddYears(-40 + i),
                        CreatedAt = new DateTime(2025, 6, 7, 11, 0, 0),
                    }
                );
            }

            b.HasData(consultants);
        });

        modelBuilder.Entity<Contract>(b =>
        {
            b.HasOne(e => e.Client)
                .WithMany(e => e.Contracts)
                .HasForeignKey(e => e.ClientId)
                .IsRequired();

            b.HasOne(c => c.Admin)
                .WithMany(c => c.AdministeredContracts)
                .HasForeignKey(c => c.AdminId)
                .IsRequired();

            b.HasOne(e => e.Institution)
                .WithMany(e => e.Contracts)
                .HasForeignKey(e => e.InstitutionId)
                .IsRequired();


            var contracts = new List<Contract>();

            for (var i = 0; i < 20; i++)
            {
                contracts.Add(new Contract
                    {
                        Id = Faker.GetGuid(i),
                        ClientId = Faker.GetGuid(i % 8),
                        AdminId = Faker.GetGuid(i % 7),
                        InstitutionId = (i % 3) + 1,
                        Created = DateTime.Today.AddDays(-i),
                        Effective = DateTime.Today.AddDays(i % 5),
                        Closed = DateTime.Today.AddDays(i % 10 + 5),
                        CreatedAt = new DateTime(2025, 6, 7, 12, 0, 0),
                    }
                );
            }

            b.HasData(contracts);
        });
    }
}
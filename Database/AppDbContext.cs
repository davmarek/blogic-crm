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
            b.HasMany(e => e.Contracts)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .IsRequired();

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
                        Birthday = DateTime.Today.AddYears(-40+i)
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
                        Birthday = DateTime.Today.AddYears(-40+i)
                    }
                );
            }

            b.HasData(consultants);
        });

        modelBuilder.Entity<Contract>(b =>
        {
            b.HasOne(c => c.Admin)
                .WithMany(c => c.AdministeredContracts)
                .HasForeignKey(c => c.AdminId)
                .IsRequired();

            /*for( var i = 0; i < 20; i++)
            {
                b.HasData(new Contract
                {
                    Id = Guid.Parse($"00000000-0000-0000-0000-{i + 1:D12}"),
                    ClientId = Guid.Parse($"00000000-0000-0000-0000-{(i % 10) + 1:D12}"),
                    AdminId = Guid.Parse($"00000000-0000-0000-0000-{(i % 10) + 1:D12}"),
                    InstitutionId = (i % 3) + 1,
                    Created = DateTime.Today.AddDays(-i),
                    Effective = DateTime.Today.AddDays(i % 5),
                    Closed = DateTime.Today.AddDays(i % 10 + 5)
                });
            }*/

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
                        Closed = DateTime.Today.AddDays(i % 10 + 5)
                    }
                );
            }

            b.HasData(contracts);

            /*b.HasData(
                new Contract
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    ClientId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    AdminId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    InstitutionId = 1,
                    Created = DateTime.Today,
                    Effective = DateTime.Today.AddDays(1),
                    Closed = DateTime.Today.AddDays(7),
                },
                new Contract
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    ClientId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    AdminId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    InstitutionId = 2,
                    Created = DateTime.Today.AddDays(-3),
                    Effective = DateTime.Today,
                    Closed = DateTime.Today.AddDays(30),
                },
                new Contract
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    ClientId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    AdminId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    InstitutionId = 1,
                    Created = DateTime.Today,
                    Effective = DateTime.Today.AddDays(1),
                    Closed = DateTime.Today.AddDays(7),
                },
                new Contract
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    ClientId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    AdminId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    InstitutionId = 2,
                    Created = DateTime.Today.AddDays(-3),
                    Effective = DateTime.Today,
                    Closed = DateTime.Today.AddDays(30),
                }
            );*/
        });
    }
}
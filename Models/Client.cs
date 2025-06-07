using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Client
{
    [Key] public Guid Id { get; set; }

    [DisplayName("First Name")]
    [MaxLength(256)]
    public required string FirstName { get; set; }

    [DisplayName("Last Name")]
    [MaxLength(256)]
    public required string LastName { get; set; }


    [MaxLength(256)] public required string Email { get; set; }

    [MaxLength(256)] public required string Phone { get; set; }

    [DisplayName("Birth Number")]
    [MaxLength(256)]
    public required string BirthNumber { get; set; }

    [DataType(DataType.Date)] public required DateTime Birthday { get; set; }

    // Contract Relationship (Has-Many)
    public ICollection<Contract> Contracts { get; set; } = [];
    
    // Computed properties
    public string FullName => $"{FirstName} {LastName}";
}
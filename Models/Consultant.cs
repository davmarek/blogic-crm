using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Consultant
{
    [Key] public Guid Id { get; set; }
    
    [DataType(DataType.Date)] public DateTime CreatedAt { get; set; } = DateTime.Now;


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


    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
    public required DateTime Birthdate { get; set; }

    // Contract Relationship
    public ICollection<Contract> AdministeredContracts { get; set; } = [];
    public ICollection<Contract> ParticipatingContracts { get; set; } = [];
    
    // Computed properties
    public string FullName => $"{FirstName} {LastName}";
    public int Age => DateTime.Now.Year - Birthdate.Year - (DateTime.Now.DayOfYear < Birthdate.DayOfYear ? 1 : 0);
}
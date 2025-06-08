using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Client
{
    [Key] public Guid Id { get; set; }
    
    [DataType(DataType.Date)] public DateTime CreatedAt { get; set; } = DateTime.Now;


    [DisplayName("First Name")]
    [StringLength(150, MinimumLength = 1)]
    public required string FirstName { get; set; }


    [DisplayName("Last Name")]
    [Required]
    [StringLength(150, MinimumLength = 1)]
    public required string LastName { get; set; }


    [Required]
    [StringLength(256, MinimumLength = 1)]
    public required string Email { get; set; }


    [Required]
    [StringLength(256, MinimumLength = 1)]
    public required string Phone { get; set; }

    [Required]
    [DisplayName("Birth Number")]
    [StringLength(256, MinimumLength = 1)]
    public required string BirthNumber { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
    public required DateTime Birthdate { get; set; }

    // Contract Relationship (Has-Many)
    public ICollection<Contract> Contracts { get; set; } = [];

    // Computed properties
    [DisplayName("Full Name")]
    public string FullName => $"{FirstName} {LastName}";
    public int Age => DateTime.Now.Year - Birthdate.Year - (DateTime.Now.DayOfYear < Birthdate.DayOfYear ? 1 : 0);
}
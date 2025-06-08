using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Consultant
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


    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public required DateTime Birthday { get; set; }

    // Contract Relationship
    public ICollection<Contract> AdministeredContracts { get; set; } = [];
    public ICollection<Contract> ParticipatingContracts { get; set; } = [];
    
    // Computed properties
    public string FullName => $"{FirstName} {LastName}";
    public int Age => DateTime.Now.Year - Birthday.Year - (DateTime.Now.DayOfYear < Birthday.DayOfYear ? 1 : 0);
}
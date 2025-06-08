using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Contract
{
    [Key] public Guid Id { get; set; }

    [DataType(DataType.Date)] public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Created { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Effective { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Closed { get; set; }

    // Foreign keys
    public Guid ClientId { get; set; }
    public Guid AdminId { get; set; }
    public int InstitutionId { get; set; }

    // Navigation properties
    public Client Client { get; set; } = null!;
    public Consultant Admin { get; set; } = null!;
    public Institution Institution { get; set; } = null!;
    public ICollection<Consultant> Consultants { get; set; } = [];

    // Computed properties

    [Display(Name = "ID")]
    public string ShortId => Id.ToString()[..4] + "..." + Id.ToString()[(Id.ToString().Length - 4)..];
}
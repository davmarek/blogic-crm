using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Institution
{
    [Key]
    [Display(Name = "ID")]
    public int Id { get; set; }

    [Required] [MaxLength(256)] public required string Name { get; set; }

    public ICollection<Contract> Contracts { get; set; } = [];
}
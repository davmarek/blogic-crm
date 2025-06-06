using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models.ViewModels;

public class InstitutionIndexViewModel
{
    public IEnumerable<Institution> Institutions { get; set; } = [];
    
    [Required]
    [MaxLength(256)]
    public string NewInstitutionName { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace BlogicCRM.Models.ViewModels;

public class ContractFormViewModel
{

    public IEnumerable<Institution> Institutions { get; set; } = [];
    public IEnumerable<Client> Clients { get; set; } = [];
    public IEnumerable<Consultant> Consultants { get; set; } = [];
    
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Client is required.")]
    public Guid ClientId { get; set; }
    
    [Required(ErrorMessage = "Consultant is required.")]
    public Guid AdminId { get; set; }
    
    [Required(ErrorMessage = "Institution is required.")]
    public int InstitutionId { get; set; }
    
    
    [Required(ErrorMessage = "Date of creation is required.")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    [Required(ErrorMessage = "Effective date is required.")]
    public DateTime EffectiveDate { get; set; } = DateTime.Now;
    
    [Required(ErrorMessage = "Closing date is required.")]
    public DateTime ClosingDate { get; set; } = DateTime.Now;
    
    public List<Guid> ConsultantIds { get; set; } = [];
}
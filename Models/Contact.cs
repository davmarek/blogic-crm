using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Contact
{
    public Guid Id { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime Created { get; set; }
    [DataType(DataType.Date)]
    public DateTime Effective { get; set; }
    [DataType(DataType.Date)]
    public DateTime Closed { get; set; }
    
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    
    public int InstitutionId { get; set; }
    public Institution Institution { get; set; }
}
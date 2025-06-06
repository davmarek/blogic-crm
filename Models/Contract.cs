using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Contract
{
    [Key] public Guid Id { get; set; }


    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d}")]
    public DateTime Created { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d}")]
    public DateTime Effective { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d}")]
    public DateTime Closed { get; set; }

    // Client Relationship (Belongs-To-One)
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;

    // Institution Relationship (Belongs-To-One)
    public int InstitutionId { get; set; }
    public Institution Institution { get; set; } = null!;
    
    // Admin (Consultant) Relationship (Belongs-To-One)
    public Guid AdminId { get; set; }
    public Consultant Admin { get; set; } = null!;
    
    // Consultant Relationship (Has-Many)
    public ICollection<Consultant> Consultants { get; set; } = [];
    
}
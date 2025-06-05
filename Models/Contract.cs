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

    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public int InstitutionId { get; set; }
    public Institution Institution { get; set; } = null!;
}
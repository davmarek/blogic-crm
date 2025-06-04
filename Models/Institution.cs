using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Institution
{
    [Key]
    public required int Id { get; set; }
    
    [MaxLength(256)]
    public required string Name { get; set; }
    
    public ICollection<Contract> Contracts { get; set; } = [];

}
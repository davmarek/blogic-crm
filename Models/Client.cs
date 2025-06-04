using System.ComponentModel.DataAnnotations;

namespace BlogicCRM.Models;

public class Client
{
    [Key]
    public required Guid Id { get; set; }
    
    [MaxLength(256)]
    public required string FirstName { get; set; }
    
    [MaxLength(256)]
    public required string LastName { get; set; }
    
    [MaxLength(256)]
    public required string Email { get; set; }
    
    [MaxLength(256)]
    public required string Phone { get; set; }

    public ICollection<Contract> Contracts { get; set; } = [];

}
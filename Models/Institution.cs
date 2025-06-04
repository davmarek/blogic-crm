namespace BlogicCRM.Models;

public class Institution
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // TODO: add relation to contracts
    // public ICollection<Contact> Contracts { get; set; }
    
}
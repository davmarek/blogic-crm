using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace BlogicCRM.Models.ViewModels;

public class SearchViewModel
{
    public required string SearchTerm { get; set; }
    
    public IEnumerable<Contract> Contracts { get; set; } = [];
    public IEnumerable<Client> Clients { get; set; } = [];
    public IEnumerable<Consultant> Consultants { get; set; } = [];
}
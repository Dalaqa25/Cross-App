using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Project")]
public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreateOn { get; set; }
    public DateTime DeleteDate { get; set; }
    
    public List<Protfolio> Protfolios { get; set; } = new List<Protfolio>();
}
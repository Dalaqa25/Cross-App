using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Portfolio")]
public class Protfolio
{
    public string AppUserId { get; set; }
    public int ProjectId { get; set; }
    public AppUser AppUser { get; set; }
    public Project Project { get; set; }
}
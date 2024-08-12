namespace API.Dtos.EmployerDto;

public class EmployerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string OrganizationTitle { get; set; } = string.Empty;  
}
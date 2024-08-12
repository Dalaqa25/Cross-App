namespace API.Dtos.WorkerDto;

public class WorkerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string JobTitle { get; set; } = string.Empty;
}
namespace RequestPermission.Api.Dtos;

public record EmployeeUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
}

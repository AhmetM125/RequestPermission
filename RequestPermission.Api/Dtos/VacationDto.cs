using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Dtos;

public record VacationDto
{
    public Guid Id { get; set; }
    public Guid EmpId { get; set; }
    public Employee Employee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
    public string Type { get; set; } // Paid, Unpaid, Sick, etc.
}

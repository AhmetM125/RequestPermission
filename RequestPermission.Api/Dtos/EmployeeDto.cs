using NSwag.Annotations;
using RequestPermission.Api.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RequestPermission.Api.Dtos;

public record  EmployeeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public string Title { get; set; }
    public Guid ManagerId { get; set; }

}

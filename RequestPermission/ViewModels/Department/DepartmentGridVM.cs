using RequestPermission.ViewModels.Employees;
using System.Text.Json.Serialization;

namespace RequestPermission.ViewModels.Department;

public record DepartmentGridVM
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }
    [JsonPropertyName("totalEmployee")]
    public int TotalEmployee { get; set; }
    [JsonPropertyName("employeeDtos")]
    public IEnumerable<EmployeesGridVM>? EmployeeVMs { get; set; }
}

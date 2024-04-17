using System.Text.Json.Serialization;

namespace RequestPermission.ViewModels.Employees;

public class EmployeeInsertDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    public int Department { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("managerId")]
    public Guid ManagerId { get; set; }
}

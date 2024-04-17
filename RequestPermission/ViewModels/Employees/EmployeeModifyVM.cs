using System.Text.Json.Serialization;

namespace RequestPermission.ViewModels.Employees;

public record EmployeeModifyVM
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("surname")]
    public string Surname { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("position")]
    public string Position { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }

}

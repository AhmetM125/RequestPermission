using System.Text.Json.Serialization;

namespace RequestPermission.ViewModels.Employees;

public record  EmployeesGridVM
{
    public EmployeesGridVM(string fullName, string email, int department, string title)
    {
        FullName = fullName;
        Email = email;
        Department = department;
        Title = title;
    }

    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    [JsonPropertyName("name")]
    public string FullName { get; init; }
    [JsonPropertyName("email")]
    public string Email { get; init; }
    [JsonPropertyName("department")]
    public int Department { get; init; }
    [JsonPropertyName("title")]
    public string Title { get; init; }

}

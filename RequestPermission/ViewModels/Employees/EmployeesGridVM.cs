using System.Text.Json.Serialization;

namespace RequestPermission.ViewModels.Employees;

public record  EmployeesGridVM
{
    public EmployeesGridVM(string name,string surname, string email, int department, string title)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Department = department;
        Title = title;
        FullName = $"{name} {surname}";
    }

    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    [JsonPropertyName("name")]
    public string Name { get; init; }
    [JsonPropertyName("surname")]
    public string Surname { get; init; }
    
    [JsonPropertyName("email")]
    public string Email { get; init; }
    [JsonPropertyName("department")]
    public int Department { get; init; }
    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonIgnore]
    public string FullName { get; init; }

}

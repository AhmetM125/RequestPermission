using System.Text.Json.Serialization;

namespace RequestPermission.ViewModels.Employees
{
    public record class EmployeesGridVM
    {
        public EmployeesGridVM(string fullName, string email, string department, string title)
        {
            FullName = fullName;
            Email = email;
            Department = department;
            Title = title;
        }
        [JsonPropertyName("id")]
      
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
     
        public string FullName { get; init; }
        [JsonPropertyName("email")]
        public string Email { get; init; }
        [JsonPropertyName("department")]

        public string Department { get; init; }
        [JsonPropertyName("title")]
        public string Title { get; init; }

    }
}

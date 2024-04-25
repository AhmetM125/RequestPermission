using System.Text.Json.Serialization;

namespace RequestPermission.ViewModels.Security;

public record EmployeeLoginVM
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }

}

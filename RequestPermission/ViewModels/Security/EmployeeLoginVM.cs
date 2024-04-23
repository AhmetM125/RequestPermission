namespace RequestPermission.ViewModels.Security;

public record EmployeeLoginVM
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool LoginStatus { get; set; } = false;
    public string JwtToken { get; set; }

}

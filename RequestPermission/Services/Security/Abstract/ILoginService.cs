using RequestPermission.ViewModels.Security;

namespace RequestPermission.Services.Security.Abstract;

public interface ILoginService
{
    Task<LoginResponse> Login(EmployeeLoginVM employeeLogin);
}

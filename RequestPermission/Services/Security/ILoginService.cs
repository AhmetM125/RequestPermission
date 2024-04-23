using RequestPermission.ViewModels.Security;

namespace RequestPermission.Services.Security;

public interface ILoginService
{
    EmployeeLoginVM Login(EmployeeLoginVM employeeLogin);
}

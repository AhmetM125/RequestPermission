using RequestPermission.Services.BaseService;
using RequestPermission.ViewModels.Security;

namespace RequestPermission.Services.Security;

public class LoginService : BaseApi, ILoginService
{
    public LoginService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "api/Security/";
    }

    public EmployeeLoginVM Login(EmployeeLoginVM employeeLogin)
    {
        return HandleLoginPostResponse(employeeLogin, "Login");
    }
}

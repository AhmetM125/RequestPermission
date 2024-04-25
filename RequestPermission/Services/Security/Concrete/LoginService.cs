using RequestPermission.Base;
using RequestPermission.Services.BaseService;
using RequestPermission.Services.Security.Abstract;
using RequestPermission.ViewModels.Security;

namespace RequestPermission.Services.Security.Concrete;

public class LoginService : BaseApi, ILoginService
{
    private readonly AuthorizationProvider _authorizationProvider;
    public LoginService(HttpClient httpClient, AuthorizationProvider authorizationProvider) : base(httpClient)
    {
        ApiName = "Security/";
        _authorizationProvider = authorizationProvider;
    }

    public async Task<LoginResponse> Login(EmployeeLoginVM employee)
    {
        var response = await HandleLoginPostResponse<LoginResponse, EmployeeLoginVM>(employee, "Login");
        var token = new TokenVM() { Token = response.JwtToken };
        if (response != null)
        {
            await _authorizationProvider.MarkUserAsAuthenticated(token, true);
        }
        return response;
    }
}

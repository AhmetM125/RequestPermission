using RequestPermission.Api.Dtos.Security;

namespace RequestPermission.Api.Services.Contracts;

public interface ISecurityService
{
    EmployeeLoginVM Login(EmployeeLoginVM employee);
    void Register(EmployeeRegisterVM employee);
}

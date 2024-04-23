using Microsoft.AspNetCore.Mvc;
using RequestPermission.Api.Dtos.Security;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly ISecurityService _securityService;
    public SecurityController(ISecurityService securityService)
    {
        _securityService = securityService;
    }
    [HttpPost("Login")]
    public IActionResult Login(EmployeeLoginVM employee)
    {
        var result = _securityService.Login(employee);
        if (result == null)
        {
            return Unauthorized();
        }
        return Ok(result);
    }
    public IActionResult Register(EmployeeRegisterVM employee)
    {
        var result = _securityService.Register(employee);
        return Ok(result);
    }
}

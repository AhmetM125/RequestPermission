using Microsoft.IdentityModel.Tokens;
using RequestPermission.Api.Dtos.Security;
using RequestPermission.Api.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RequestPermission.Api.Services.Concrete;

public class SecurityService : ISecurityService
{
    private readonly IConfiguration _configuration;
    private readonly IEfSecurityDal _efSecurityDal;
    public SecurityService(IConfiguration configuration, IEfSecurityDal efSecurityDal)
    {
        _configuration = configuration;
        _efSecurityDal = efSecurityDal;
    }
    public EmployeeLoginVM Login(EmployeeLoginVM employee)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(int.Parse(_configuration["Jwt:JwtExpireDays"].ToString()));

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, employee.Username),
        };
        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],_configuration["Jwt:Audience"],
                                             claims,expires: expires,signingCredentials: credentials);

        String tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        //employee.JwtToken = tokenString;

        return employee;
    }

    public void Register(EmployeeRegisterVM employee)
    {
        throw new NotImplementedException();
    }
}

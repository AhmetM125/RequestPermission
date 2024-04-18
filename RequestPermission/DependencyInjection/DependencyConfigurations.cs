using RequestPermission.Services.Department.Abstract;
using RequestPermission.Services.Department.Concrete;
using RequestPermission.Services.Employee.Abstract;
using RequestPermission.Services.Employee.Concrete;

namespace RequestPermission.DependencyInjection;

public static class DependencyConfigurations
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
    }
}

using RequestPermission.Api.Dtos;

namespace RequestPermission.Api.Services.Concrete
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetEmployees();
        void InsertNewEmployee(EmployeeDto employee);
    }
}

using RequestPermission.Api.Dtos;

namespace RequestPermission.Api.Services.Concrete
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees();
        List<EmployeeDto> GetEmployeesRawQuery();
        void InsertNewEmployee(EmployeeDto employee);

    }
}

using RequestPermission.Api.Dtos;

namespace RequestPermission.Api.Services.Concrete
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployeeForModify(Guid employeeId);
        Task<List<EmployeeDto>> GetEmployees();
        List<EmployeeDto> GetEmployeesRawQuery();
        Task InsertNewEmployee(EmployeeDto employee);
        void UpdateUser(EmployeeDto employee);
    }
}

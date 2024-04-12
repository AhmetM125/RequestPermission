using RequestPermission.ViewModels.Employees;

namespace RequestPermission.Services.Employee.Abstract
{
    public interface IEmployeeService
    {
        Task<List<EmployeesGridVM>> GetAllEmployees();
    }
}

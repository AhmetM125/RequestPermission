using RequestPermission.ViewModels.Employees;

namespace RequestPermission.Services.Employee.Abstract;

public interface IEmployeeService
{
    Task DeleteSelectedEmployee(Guid employeeId);
    Task<List<EmployeesGridVM>?> GetAllEmployees();
    Task<EmployeeModifyVM> GetEmployeeForModify(Guid employeeId);
    Task InsertUser(EmployeeInsertDto employeeModifyVM);
    Task UpdateUser(EmployeeModifyVM employeeModifyVM);
}

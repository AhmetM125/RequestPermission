using Microsoft.AspNetCore.Components;
using RequestPermission.ViewModels.Employees;
using RequestPermission.Services.Employee.Abstract;
namespace RequestPermission.Components.Pages.Employees;

public partial class IndexComponent : ComponentBase
{
    private List<EmployeesGridVM> employees = new List<EmployeesGridVM>();
    [Inject] private IEmployeeService _employeeService { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await LoadEmployees();
        await base.OnInitializedAsync();
    }
    async Task LoadEmployees()
    {
        employees = await _employeeService.GetAllEmployees();
    }
    void LoadEmployeeByPageNumber(int pageNum)
    {
        employees.Clear();
        //employees = _employeeService.GetEmployeesByPageNumber(pageNum);
    }


}

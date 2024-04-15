using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using RequestPermission.Components.CustomComponents;
using RequestPermission.Services.Employee.Abstract;
using RequestPermission.ViewModels.Employees;
using System.Reflection;
namespace RequestPermission.Components.Pages.Employees;

public partial class IndexComponent : ComponentBase
{
    private List<EmployeesGridVM> employees = new List<EmployeesGridVM>();
    [Inject] private IEmployeeService _employeeService { get; set; }
    [Inject] public IModalService Modal { get; set; } = default!;
    protected override async Task OnInitializedAsync()
    {
        await LoadEmployees();
        await base.OnInitializedAsync();
    }
    async Task LoadEmployees()
    {
        employees = await _employeeService.GetAllEmployees()
                            ?? Enumerable.Empty<EmployeesGridVM>().ToList();

    }

    void ShowModal()
    {
        ModalParameters mParams = new ModalParameters();
        mParams.Add("Title", "Edit Employee");
        mParams.Add("Description", "Edit Employee");
        mParams.Add("Body", "Employees\\ModiyComponent");
        ModalOptions modalOptions = new ModalOptions();
        modalOptions.Position = ModalPosition.TopCenter;
        ModalComponent modalComponent = new ModalComponent();

        Modal.Show<ModalComponent>("Edit Employee", mParams, modalOptions);
    }

    async Task GetEmployees()
    {
        await LoadEmployees();
    }
    void openModal()
    {

        Modal.Show<ModiyComponent>("Edit Employee");
    }


}

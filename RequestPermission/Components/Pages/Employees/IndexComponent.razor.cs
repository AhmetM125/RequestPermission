using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RequestPermission.Base;
using RequestPermission.Services.Employee.Abstract;
using RequestPermission.ViewModels.Employees;

namespace RequestPermission.Components.Pages.Employees;

public partial class IndexComponent : RazorBaseComponent
{
    private List<EmployeesGridVM> employees;
    [Inject] private IEmployeeService _employeeService { get; set; }

    EmployeeModifyVM employeeModifyVM = new EmployeeModifyVM();
    PageStatus PageStatus { get; set; } = PageStatus.List;

    protected override async Task OnInitializedAsync()
    {
        if (employees is null) 
            await LoadEmployees();

        await base.OnInitializedAsync();
    }
    async Task LoadEmployees()
    {
        employees = await _employeeService.GetAllEmployees()
                            ?? Enumerable.Empty<EmployeesGridVM>().ToList();
    }
    async Task GetEmployees() => await LoadEmployees();
    async Task openModal(Guid employeeId)
    {
        var result = employees.FirstOrDefault(x => x.Id == employeeId);
        employeeModifyVM.Id = result.Id;
        await InvokeVoidJavascript();
    }
    async Task InsertEmployee(PageStatus pageStatus)
    {
        PageStatus = pageStatus;
        employeeModifyVM = new();
        await InvokeVoidJavascript();
    }
    async Task InvokeVoidJavascript()
      => await JSRuntime.InvokeVoidAsync("OpenModal", "employeeModifyModal");

    async Task DeleteEmployee(Guid employeeId)
    {
        await _employeeService.DeleteSelectedEmployee(employeeId);
        await LoadEmployees();
    }



}









//void ShowModal()
//{
//    ModalParameters mParams = new ModalParameters();
//    mParams.Add("Title", "Edit Employee");
//    mParams.Add("Description", "Edit Employee");
//    mParams.Add("Body", "Employees\\ModiyComponent");
//    ModalOptions modalOptions = new ModalOptions();
//    modalOptions.Position = ModalPosition.TopCenter;
//    ModalComponent modalComponent = new ModalComponent();

//    Modal.Show<ModalComponent>("Edit Employee", mParams, modalOptions);
//}

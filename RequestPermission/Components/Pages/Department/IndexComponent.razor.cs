using Microsoft.AspNetCore.Components;
using RequestPermission.Base;
using RequestPermission.Services.Department.Abstract;
using RequestPermission.ViewModels.Department;
namespace RequestPermission.Components.Pages.Department;

public partial class  IndexComponent : RazorBaseComponent
{
    [Inject] private IDepartmentService _departmentService { get; set; }
    List<DepartmentGridVM>? DepartmentGridVMs;
    protected override async Task OnInitializedAsync()
    {
        if(DepartmentGridVMs == null)  await LoadData();
        await base.OnInitializedAsync();
    }
    private async Task LoadData()
     => DepartmentGridVMs = await _departmentService.GetDepartmentsAsync() ;

}

using RequestPermission.Services.BaseService;
using RequestPermission.Services.Department.Abstract;
using RequestPermission.ViewModels.Department;

namespace RequestPermission.Services.Department.Concrete;

public class DepartmentService : BaseApi, IDepartmentService
{
    public DepartmentService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "api/Department/";
    }

    public async Task AddDepartmentAsync(DepartmentInsertVM department)
     => await HandlePostResponse(department);

    public async Task DeleteDepartmentAsync(int id)
     => await HandleDeleteResponseByIntId(id, $"{id}");

    public async Task<List<DepartmentGridVM>?> GetActiveDepartmentsAsync()
     => await HandleReadResponse<DepartmentGridVM>("GetActiveDepartments");

    public async Task<DepartmentModifyVM?> GetDepartmentByIdAsync(int id)
     => await HandleSingleReadResponse<DepartmentModifyVM>($"{id}");

    public Task<List<DepartmentGridVM>?> GetDepartmentsAsync()
     => HandleReadResponse<DepartmentGridVM>("GetAllDepartments");

    public Task UpdateDepartmentAsync(DepartmentModifyVM department)
     => HandlePutResponse(department);
}

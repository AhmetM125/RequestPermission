using RequestPermission.ViewModels.Department;

namespace RequestPermission.Services.Department.Abstract;

public interface IDepartmentService
{ 
    Task<List<DepartmentGridVM>?> GetDepartmentsAsync();
    Task<List<DepartmentGridVM>?> GetActiveDepartmentsAsync();
    Task<DepartmentModifyVM?> GetDepartmentByIdAsync(int id);
    Task AddDepartmentAsync(DepartmentInsertVM department);
    Task UpdateDepartmentAsync(DepartmentModifyVM department);
    Task DeleteDepartmentAsync(int id);
}

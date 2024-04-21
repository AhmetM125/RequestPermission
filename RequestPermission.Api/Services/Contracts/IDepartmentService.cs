using RequestPermission.Api.Dtos.Department;

namespace RequestPermission.Api.Services.Contracts;

public interface IDepartmentService
{
    void DeleteDepartment(int departmentId);
    Task<DepartmentModifyDto> GetDepartmentForModify(int departmentId);
    Task<List<DepartmentListDto>> GetDepartments();
    Task<List<DepartmentDto>> GetDepartmentsRawQuery();
    Task InsertNewDepartment(DepartmentInsertDto department);
    void UpdateDepartment(DepartmentModifyDto department);
}

using RequestPermission.Api.Dtos.Department;

namespace RequestPermission.Api.Services.Contracts;

public interface IDepartmentService
{
    Task DeleteDepartment(Guid departmentId);
    Task<DepartmentModifyDto> GetDepartmentForModify(Guid departmentId);
    Task<List<DepartmentListDto>> GetDepartments();
    List<DepartmentDto> GetDepartmentsRawQuery();
    Task InsertNewDepartment(DepartmentInsertDto department);
    void UpdateDepartment(DepartmentModifyDto department);
}

using RequestPermission.Api.Dtos.Department;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.Services.Concrete;

public class DepartmentService : IDepartmentService
{
    public Task DeleteDepartment(Guid departmentId)
    {
        throw new NotImplementedException();
    }

    public DepartmentModifyDto GetDepartmentForModify(Guid departmentId)
    {
        throw new NotImplementedException();
    }

    public Task<List<DepartmentListDto>> GetDepartments()
    {
        throw new NotImplementedException();
    }

    public List<DepartmentDto> GetDepartmentsRawQuery()
    {
        throw new NotImplementedException();
    }

    public Task InsertNewDepartment(DepartmentInsertDto department)
    {
        throw new NotImplementedException();
    }

    public void UpdateDepartment(DepartmentModifyDto department)
    {
        throw new NotImplementedException();
    }
}

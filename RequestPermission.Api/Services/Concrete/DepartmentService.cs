using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Dtos.Department;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.Services.Concrete;

public class DepartmentService : IDepartmentService
{
    private readonly IEfDepartmentDal _efDepartmentDal;
    private readonly IMapper _mapper;

    public DepartmentService(IEfDepartmentDal efDepartmentDal, IMapper mapper)
    {
        _efDepartmentDal = efDepartmentDal;
        _mapper = mapper;
    }

    public void DeleteDepartment(Guid departmentId)
    {
        _efDepartmentDal.DeleteById(departmentId);
    }

    public async Task<DepartmentModifyDto> GetDepartmentForModify(Guid departmentId)
    {
        return _efDepartmentDal.GetAsync()
    }

    public async Task<List<DepartmentListDto>> GetDepartments()
    {
        return _mapper.Map<List<DepartmentListDto>>
            (await _efDepartmentDal.GetQueryable()
            .AsNoTracking().ToListAsync());
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

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Dtos.Department;
using RequestPermission.Api.Entity;
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

    public void DeleteDepartment(int departmentId)
    {
        _efDepartmentDal.DeleteById(departmentId);
    }

    public async Task<DepartmentModifyDto> GetDepartmentForModify(int departmentId)
    {
        return _mapper.Map<DepartmentModifyDto>(await _efDepartmentDal.GetByFilterAsync(x => x.D_ID == departmentId));
    }

    public async Task<List<DepartmentListDto>> GetDepartments()
    {
        return _mapper.Map<List<DepartmentListDto>>
            (await _efDepartmentDal.GetQueryable()
            .AsNoTracking().ToListAsync());
    }

    public async Task<List<DepartmentDto>> GetDepartmentsRawQuery()
    {
        return _mapper.Map<List<DepartmentDto>>(await _efDepartmentDal.GetQueryable().ToListAsync());
    }

    public async Task InsertNewDepartment(DepartmentInsertDto department)
    {
        await _efDepartmentDal.AddAsync(_mapper.Map<Department>(department));
    }

    public void UpdateDepartment(DepartmentModifyDto department)
    {
        _mapper.Map<Department>(department);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Dtos;
using RequestPermission.Api.Entity;
using RequestPermission.Api.Services.Concrete;
using System.Diagnostics;

namespace RequestPermission.Api.Services.Contracts
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEfEmployeeDal _efEmployeeDal;
        private readonly IMapper _mapper;
        public EmployeeService(IEfEmployeeDal efEmployeeDal, IMapper mapper)
        {
            _efEmployeeDal = efEmployeeDal;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            Stopwatch s = Stopwatch.StartNew();
            var employees = await _efEmployeeDal.GetQueryable().AsNoTracking().ToListAsync();
            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);
            s.Stop();
            Debug.WriteLine($"GetEmployees took {s.ElapsedMilliseconds} ms");
            return employeesDto;
        }

        public List<EmployeeDto> GetEmployeesRawQuery()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string query = "SELECT * FROM Employees";
            var employees = _efEmployeeDal.GetWithRawSql(query);
            stopwatch.Stop();
            Debug.WriteLine($"GetEmployeesRawQuery took {stopwatch.ElapsedMilliseconds} ms");
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public void InsertNewEmployee(EmployeeDto employee)
        {
            _efEmployeeDal.Add(new Employee()
            {
                E_DEPARTMENT = employee.Department,
                E_ID = Guid.NewGuid(),
                E_NAME = employee.Name,
                E_TITLE = employee.Title,
            });
            _efEmployeeDal.Save();
        }
    }
}

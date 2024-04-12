using AutoMapper;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Dtos;
using RequestPermission.Api.Entity;
using RequestPermission.Api.Services.Concrete;

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

        public List<EmployeeDto> GetEmployees()
        {
            var employees = _efEmployeeDal.GetAll();
            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);
            return employeesDto;
        }

        public void InsertNewEmployee(EmployeeDto employee)
        {
            _efEmployeeDal.Add(new Employee()
            {
                E_DEPARTMENT = employee.Department,
                E_EMAIL = employee.Email,
                E_ID = Guid.NewGuid(),
                E_NAME = employee.Name,
                E_TITLE = employee.Title,
                E_MANAGERID = _efEmployeeDal.GetFirstOrDefault().E_ID // i will change it later for test purpose
            });
            _efEmployeeDal.Save();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestPermission.Api.DataLayer.Generic;
using RequestPermission.Api.Dtos;
using RequestPermission.Api.Entity;
using RequestPermission.Api.Services.Concrete;
using System.Net;

namespace RequestPermission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        [HttpPost("InsertNewEmployee")]
        public IActionResult CreateNewUser(EmployeeAddDto employee)
        {
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            _employeeService.InsertNewEmployee(employeeDto);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpGet("GetAllEmployees")]
        [ProducesResponseType(typeof(List<EmployeeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employeesDto = _employeeService.GetEmployeesRawQuery();
            var employees = await _employeeService.GetEmployees();
            return Ok(employees);
        }
        [HttpGet("GetEmployeeForModify/{employeeId:Guid}")]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployeeForModify(Guid employeeId)
        {
            var employee = _employeeService.GetEmployeeForModify(employeeId);
            return Ok(employee);
        }
        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(EmployeeUpdateDto employee)
        {
            _employeeService.UpdateUser(_mapper.Map<EmployeeDto>(employee));
            return Ok();
        }
    }
}

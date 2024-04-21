using Microsoft.AspNetCore.Mvc;
using RequestPermission.Api.Dtos.Department;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("GetAllDepartments")]
    [ProducesResponseType(typeof(List<DepartmentListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _departmentService.GetDepartments();
        return Ok(departments);
    }

    //[HttpGet("GetActiveDepartments")]
    //public async Task<IActionResult> GetActiveDepartments()
    //{
    //    return null;
    //    //var departments = await _departmentService.GetActiveDepartmentsAsync();
    //    //return Ok(departments);
    //}

    //[HttpGet("GetDepartmentById/{id}")]
    //public async Task<IActionResult> GetDepartmentById(int id)
    //{
    //    return null;
    //    //var department = await _departmentService.GetDepartmentByIdAsync(id);
    //    //return Ok(department);
    //}

    //[HttpPost("AddDepartment")]
    //public async Task<IActionResult> AddDepartment()
    //{
    //    return null;
      
    //}

    //[HttpPut("UpdateDepartment")]
    //public async Task<IActionResult> UpdateDepartment()
    //{
    //    return null;
     
    //}

    //[HttpDelete("DeleteDepartment/{id}")]
    //public async Task<IActionResult> DeleteDepartment(int id)
    //{
    //    return null;
       
    //}
}

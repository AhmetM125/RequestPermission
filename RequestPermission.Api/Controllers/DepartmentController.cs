using Microsoft.AspNetCore.Mvc;

namespace RequestPermission.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    //private readonly IDepartmentService _departmentService;

    //public DepartmentController(IDepartmentService departmentService)
    //{
    //    _departmentService = departmentService;
    //}

    //[HttpGet("GetDepartments")]
    //public async Task<IActionResult> GetDepartments()
    //{
    //    var departments = await _departmentService.GetDepartmentsAsync();
    //    return Ok(departments);
    //}

    //[HttpGet("GetActiveDepartments")]
    //public async Task<IActionResult> GetActiveDepartments()
    //{
    //    var departments = await _departmentService.GetActiveDepartmentsAsync();
    //    return Ok(departments);
    //}

    //[HttpGet("GetDepartmentById/{id}")]
    //public async Task<IActionResult> GetDepartmentById(int id)
    //{
    //    var department = await _departmentService.GetDepartmentByIdAsync(id);
    //    return Ok(department);
    //}

    //[HttpPost("AddDepartment")]
    //public async Task<IActionResult> AddDepartment(DepartmentInsertVM department)
    //{
    //    await _departmentService.AddDepartmentAsync(department);
    //    return Ok();
    //}

    //[HttpPut("UpdateDepartment")]
    //public async Task<IActionResult> UpdateDepartment(DepartmentModifyVM department)
    //{
    //    await _departmentService.UpdateDepartmentAsync(department);
    //    return Ok();
    //}

    //[HttpDelete("DeleteDepartment/{id}")]
    //public async Task<IActionResult> DeleteDepartment(int id)
    //{
    //    await _departmentService.DeleteDepartmentAsync(id);
    //    return Ok();
    //}
}

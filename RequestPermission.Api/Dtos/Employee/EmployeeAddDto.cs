﻿namespace RequestPermission.Api.Dtos.Employee;

public class EmployeeAddDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Department { get; set; }
    public string Title { get; set; }
    public Guid? ManagerId { get; set; }
}
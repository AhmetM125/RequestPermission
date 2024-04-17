﻿namespace RequestPermission.Api.Dtos;

public record  EmployeeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public int Department { get; set; }
    public string Title { get; set; }
    public Guid ManagerId { get; set; }

}

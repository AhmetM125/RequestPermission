namespace RequestPermission.Api.Dtos.Department;

public record DepartmentListDto
{
    public DepartmentListDto(int id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }

    public int Id { get; init; }
    public string Name { get; init; }
    public bool IsActive { get; init; }
    //public int? ParentId { get; init; }
    //public int? ManagerId { get; init; }
}

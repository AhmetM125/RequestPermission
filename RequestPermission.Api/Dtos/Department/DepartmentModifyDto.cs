namespace RequestPermission.Api.Dtos.Department;

public record DepartmentModifyDto
{
    private DepartmentModifyDto(int id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }

    public static DepartmentModifyDto CreateDepartmentForModify(int id, string name, bool isActive)
    {
        return new DepartmentModifyDto(id, name, isActive);
    }

    public int Id { get; init; }
    public string Name { get; init; }
    public bool IsActive { get; init; }
    //public int? ParentId { get; init; }
    //public int? ManagerId { get; init; }

}

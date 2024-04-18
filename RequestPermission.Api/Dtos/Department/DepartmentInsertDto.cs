namespace RequestPermission.Api.Dtos.Department;

public record DepartmentInsertDto
{
    private DepartmentInsertDto(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }

    public static DepartmentInsertDto CreateDepartmentForInsert(string name, bool isActive)
    {
        return new DepartmentInsertDto(name, isActive);
    }

    public string Name { get; init; }
    public bool IsActive { get; init; }
    //public int? ParentId { get; init; }
    //public int? ManagerId { get; init; }
}

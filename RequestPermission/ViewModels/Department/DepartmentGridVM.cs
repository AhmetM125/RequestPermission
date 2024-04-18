namespace RequestPermission.ViewModels.Department;

public record DepartmentGridVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int TotalEmployee { get; set; }
}

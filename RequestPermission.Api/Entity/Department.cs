namespace RequestPermission.Api.Entity;

public class Department : BaseEntity
{
    public int D_ID { get; set; }
    public string D_NAME { get; set; }
    public bool D_IS_ACTIVE { get; set; }
    public IEnumerable<Employee>? EMPLOYEES { get; set; }

}

namespace RequestPermission.Api.Entity;

public class Department : BaseEntity
{
    public int D_ID { get; set; }
    public string D_NAME { get; set; }
    public List<Employee> EMPLOYEES { get; set; }

}

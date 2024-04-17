namespace RequestPermission.Api.Entity;

public class Employee : BaseEntity
{
    public Guid E_ID { get; set; }
    public string E_NAME { get; set; }
    public string E_SURNAME { get; set; }
    public string E_TITLE { get; set; }
    public int E_DEPARTMENT { get; set; }
    public Guid? E_EMP_COMM_ID { get; set; }
    public Department DEPARTMENT { get; set; }
    public IEnumerable<Vacation> VACATIONS { get; set; }
    public IEnumerable<UserRole> USER_ROLES { get; set; }
    public EmployeeCommunication EMPLOYEE_COMMUNICATION { get; set; }
}

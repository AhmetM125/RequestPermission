namespace RequestPermission.Api.Entity
{
    public class EmployeeCommunication : BaseEntity
    {
        public Guid EC_ID { get; set; }
        public string EC_PHONE { get; set; }
        public string EC_ADDRESS { get; set; }
        public string EC_CITY { get; set; }
        public string EC_COUNTRY { get; set; }
        public string EC_MOBILE_PHONE { get; set; }
        public string EC_EMAIL { get; set; }
        public Employee EMPLOYEE { get; set; }
    }
}

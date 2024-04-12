using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestPermission.Api.Entity
{
    public sealed class Employee
    {
        [Key]
        public Guid E_ID { get; set; }
        public string E_NAME { get; set; }
        public string E_EMAIL { get; set; }
        public string E_DEPARTMENT { get; set; }
        public string E_TITLE { get; set; }
        public Guid? E_MANAGERID { get; set; }
        [ForeignKey("E_MANAGERID")]
        public Employee E_MANAGER { get; set; }
    }
}

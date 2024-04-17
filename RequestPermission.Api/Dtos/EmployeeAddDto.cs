using RequestPermission.Api.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestPermission.Api.Dtos
{
    public class EmployeeAddDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Department { get; set; }
        public string Title { get; set; }
        public Guid? ManagerId { get; set; }
    }
}

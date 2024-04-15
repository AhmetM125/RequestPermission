using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture
{
    public class RequestPermissionContext : DbContext
    {
        public RequestPermissionContext(DbContextOptions<RequestPermissionContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RequestPermissionContext).Assembly);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
    }
}

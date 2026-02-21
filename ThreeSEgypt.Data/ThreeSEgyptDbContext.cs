using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Data
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}

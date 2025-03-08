using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Database
{
    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}

using EFCore_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_dotnet.Data
{
    public class EmployeeContext : DbContext
    {
        /*
         * The constructor accepts a parameter of type DbContextOptions<EmployeeContext>. 
         * This allows external code to pass in the configuration, 
         * so the same DbContext can be shared between test and 
         * production code and even used with different providers.
         */
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

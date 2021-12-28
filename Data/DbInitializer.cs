using EFCore_dotnet.Models;

namespace EFCore_dotnet.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EmployeeContext context)
        {
            if(context.Employees!.Any() && context.Departments!.Any())
            {
                return; //DB has been created;
            }
            var employees = new Employee[]
            {
                new Employee
                {
                    FirstName ="John",
                    LastName ="Sena",
                    Departments = new List<Department>
                    {
                        new Department { DepartmentName = "Department1",Address="123 street"}
                    }
                },
                new Employee
                {
                    FirstName ="Steven",
                    LastName ="Peter",
                    Departments = new List<Department>
                    {
                        new Department { DepartmentName = "Department2",Address="423 street"}
                    }
                }
            };
            context.Employees!.AddRange(employees);
            context.SaveChanges();
        }
    }
}

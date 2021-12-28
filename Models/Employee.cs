namespace EFCore_dotnet.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Department> Departments  { get; set; }
    }
}

using EFCore_dotnet.Data;
using EFCore_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private EmployeeContext _context;
        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }
        [HttpGet(Name ="GetEmployee")]
        public async Task<JsonResult> Get()
        {
            var employees = await _context.Employees.Include(d=>d.Departments).ToListAsync();
            return new JsonResult(employees);
        }
        [HttpPost(Name ="CreateEmployee")]
        public async Task<JsonResult> Create([Bind("Id,FirstName,LastName")] Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return new JsonResult(employee);
        }
        [HttpPut(Name ="EditEmployee")]
        public async Task<JsonResult> Edit([Bind("Id,FirstName,LastName")] Employee employee)
        {
            var employeeSource= await _context.Employees.FirstOrDefaultAsync(x=>x.Id== employee.Id);
            if(employeeSource==null)
            {
                return new JsonResult("Employee not found");
            }
            employeeSource.FirstName = employee.FirstName;
            employeeSource.LastName = employee.LastName;
            _context.Update(employeeSource);
            await _context.SaveChangesAsync();
            return new JsonResult(employee);
        }
        [HttpDelete(Name ="DeleteEmployee")]
        public async Task<JsonResult> Delete(int? Id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
            if (employee == null)
            {
                return new JsonResult("Employee not found");
            }
            var departments = _context.Departments.Where(d => EF.Property<int>(d, "EmployeeId") == Id);
            foreach (var department in departments)
            {
                employee.Departments.Remove(department);
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return new JsonResult("Record deleted");
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace WebApi.Controllers
{
   

    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
    {
        new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
        // ...
    };

        private static List<Student> _students = new List<Student>
    {
        new Student { Id = 1, FirstName = "Alice", LastName = "Johnson", RollNumber = "A123" },
        // ...
    };

        [HttpGet("employees")]
        public IActionResult GetEmployees()
        {
            return Ok(_employees);
        }

        [HttpGet("employees/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost("employees")]
        public IActionResult CreateEmployee(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            _employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpGet("students")]
        public IActionResult GetStudents()
        {
            return Ok(_students);
        }

        [HttpGet("students/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("students")]
        public IActionResult CreateStudent(Student student)
        {
            student.Id = _students.Count + 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _students.Add(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }
    }




}

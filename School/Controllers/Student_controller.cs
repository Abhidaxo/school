using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student_controller : ControllerBase
    {
        private readonly string _connectionString;
        public Student_controller(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost("Student")]
        public IActionResult AddStudent(string Name, string place)
        {
            Student student = new Student();
            student.Student_Name = Name;
            student.Student_Place = place;

            SqlRequest<Student> newstudent = new SqlRequest<Student>(_connectionString);
            newstudent.Save(student);
            return Ok();
        }

        [HttpGet("student")]

        public IActionResult GetStudent()
        {
            SqlRequest<Student> req = new SqlRequest<Student>(_connectionString);
            IEnumerable<Student> students = req.GetAll();
            return Ok(students);
        }

        [HttpGet("student/{id}")]

        public IActionResult GetByIdStudent(int id)
        {
            SqlRequest<Student> req = new SqlRequest<Student>(_connectionString);
            var data = req.GetbyId(id);
            return Ok(data);
        }

        [HttpDelete("student/{id}")]

        public IActionResult DeleteByIdStudent(int id)
        {
            SqlRequest<Student> req = new SqlRequest<Student>(_connectionString);
            req.DeleteId(id);
            return Ok();
        }
    }
}

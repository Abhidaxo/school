using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using School_BL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly string _connectionString;
        public ValuesController(IConfiguration configuration )
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            SqlRequest<Teacher> req =  new SqlRequest<Teacher>(_connectionString);
            IEnumerable<Teacher> teachers = req.GetAll();
            return Ok(teachers);

        }

        [HttpPost("student")]
        public IActionResult StudentAdd(string Name, string place)
        {
            Student student = new Student();
            student.Student_Name = Name;
            student.Student_Place = place;

            SqlRequest<Student> newStudent = new SqlRequest<Student>(_connectionString);
            newStudent.Save(student);
            return Ok("Add");
        }

        [HttpPost("class")]

        public IActionResult ClassAdd(string name)
        {
            Class classs = new Class();
            classs.Class_Name = name;
            SqlRequest<Class> newClass = new SqlRequest<Class>(_connectionString);
            newClass.Save(classs);
            return Ok("Add");
        }
        [HttpGet("student/{id}")]

        public IActionResult GetStudentById(int id)
        {
            SqlRequest<Student> get = new SqlRequest<Student>(_connectionString);
            var data = get.GetbyId(id);
            return Ok(data);
        }
        [HttpGet("Teacher/{id}")]

        public IActionResult GetTeacherById(int id)
        {
            SqlRequest<Teacher> get = new SqlRequest<Teacher>(_connectionString);
            var data = get.GetbyId(id);
            return Ok(data);
        }

        [HttpGet("class/{id}")]

        public IActionResult GetClassById(int id)
        {
            SqlRequest<Class> get = new SqlRequest<Class>(_connectionString);
            var data = get.GetbyId(id);
            return Ok(data);
        }
        [HttpDelete("Teacher/{id}")]         
        
        public IActionResult DeleteTeacherById(int id)
        {
            SqlRequest<Teacher> get = new SqlRequest<Teacher>(_connectionString);
            get.DeleteId(id);
            return Ok();
        }

        [HttpDelete("Student/{id}")]

        public IActionResult DeleteStudentById(int id)
        {
            SqlRequest<Student> get = new SqlRequest<Student>(_connectionString);
            get.DeleteId(id);
            return Ok();

        }

        [HttpDelete("class/{id}")]

        public IActionResult DelectClassById(int id)
        {
            SqlRequest<Class> get = new SqlRequest<Class>(_connectionString);
            get.DeleteId(id);
            return Ok();    
        }
    }
}

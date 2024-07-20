using Microsoft.AspNetCore.Mvc;
using School_BL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequest : Controller
    {
        private readonly string _connectionString;

        public UserRequest(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        [HttpPost("signup")]
        public IActionResult SignUp(string Teacher_name,string Subject,string password)
        {
            Teacher teacher = new Teacher();
            teacher.Teacher_Name = Teacher_name;
            teacher.Teacher_Subject = Subject;
            teacher.password = password;
            SqlRequest<Teacher> NewTeacher = new SqlRequest<Teacher>(_connectionString);
            NewTeacher.Save(teacher);

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(string Teacher_name , string password)
        {
            Teacher teacher=new Teacher();
            teacher.Teacher_Name=Teacher_name;

           
            teacher.password=password;
            return Ok();

        }
    }
}

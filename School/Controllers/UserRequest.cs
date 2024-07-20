using Microsoft.AspNetCore.Mvc;
using School_BL.Database;
using School_BL.Services;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequest : Controller
    {
        IGenericRepositoryService<Teacher> _teacherService;

        private readonly string _connectionString;

        public UserRequest(IGenericRepositoryService<Teacher> teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("signup")]
        public IActionResult SignUp(string Teacher_name,string Subject,string password)
        {
            Teacher teacher = new Teacher();
            teacher.Teacher_Name = Teacher_name;
            teacher.Teacher_Subject = Subject;
            teacher.password = password;

            return Ok(_teacherService.Add(teacher));
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teacher_controller : ControllerBase
    {
        private readonly string _connectionstring;

        public Teacher_controller(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("defaultConnection");
        }

        [HttpPost]

        public IActionResult AddTecher(string name,string subject)
        {
            Teacher teacher = new Teacher();
            teacher.Teacher_Name = name;
            teacher.Teacher_Subject = subject;

            SqlRequest<Teacher> newteacher = new SqlRequest<Teacher>(_connectionstring);
            newteacher.Save(teacher);
            return Ok();
        }

        [HttpGet] 
        public IActionResult GetTecher()
        {
            SqlRequest<Teacher> req = new SqlRequest<Teacher>(_connectionstring);
            IEnumerable<Teacher> teachers = req.GetAll();
            return Ok(teachers);    
        }

        [HttpGet("teacher/{id}")]
        public IActionResult GetTecherById(int id)
        {
            SqlRequest<Teacher> req = new SqlRequest<Teacher>(_connectionstring);
            var data = req.GetAll();
            return Ok(data);
        }

        [HttpDelete("teacher/{id}")]

        public IActionResult DeleteGetById(int id)
        {
            SqlRequest<Teacher> req = new SqlRequest<Teacher>(_connectionstring);
            req.DeleteId(id);
            return Ok();

        }


    }
}

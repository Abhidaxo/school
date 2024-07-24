using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.GeniricInterface;
using School_DAL.Database;
using School_DAL.Model;
using School_BL.Services;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService _StudentService;
        public StudentController(IStudentService studentService) 
        {
            _StudentService = studentService;
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(string Name, string place)
        {
            Student student = new Student();
            student.Student_Name = Name;
            student.Student_Place = place;
            return Ok(_StudentService.Add(student));
        }

        [HttpGet("GetAllStudent")]
        public IActionResult GetStudent()
        {
            return Ok(_StudentService.GetAll());
        }

        [HttpGet("GetByIdStudent/{id}")]
        public IActionResult GetByIdStudent(int id)
        {
            return Ok(_StudentService.GetById(id));
        }

        [HttpDelete("DeleteByIdStudent/{id}")]
        public IActionResult DeleteByIdStudent(int id)
        {
            return Ok(_StudentService.Delete(id));
        }
    }
}

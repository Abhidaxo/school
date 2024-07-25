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
        public IActionResult AddStudent(Student student)
        {
            //Student student = new Student();
            //student.Student_Name = Name;
            //student.Student_Place = place;
            if (_StudentService.Add(student))
                return Ok("Scuccessfully added student");
            else
                return StatusCode(400);
        }

        [HttpGet("GetAllStudent")]
        public IActionResult GetStudent()
        {
            var student = _StudentService.GetAll();
            if (student.Any())
                return Ok(student);
            else
                return StatusCode(400);
        }

        [HttpGet("GetByIdStudent/{id}")]
        public IActionResult GetByIdStudent(int id)
        {
            var student = _StudentService.GetById(id);
            if ( student == null)
                return StatusCode(404);
            else
            return Ok(student);
        }

        [HttpDelete("DeleteByIdStudent/{id}")]
        public IActionResult DeleteByIdStudent(int id)
        {
            if (_StudentService.Delete(id))
                return Ok("Student Deleted");
            else
                return StatusCode(400);
        }
    }
}

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
        IGenericRepositoryService<Student> _StudentService;
        public Student_controller(IGenericRepositoryService<Student> studentService) 
        {
            _StudentService = studentService;
        }

        [HttpPost("Student")]
        public IActionResult AddStudent(string Name, string place)
        {
            Student student = new Student();
            student.Student_Name = Name;
            student.Student_Place = place;
            return Ok(_StudentService.Add(student));
        }

        [HttpGet("student")]
        public IActionResult GetStudent()
        {
            return Ok(_StudentService.GetAll());
        }

        [HttpGet("student/{id}")]
        public IActionResult GetByIdStudent(int id)
        {
            return Ok(_StudentService.GetById(id));
        }

        [HttpDelete("student/{id}")]
        public IActionResult DeleteByIdStudent(int id)
        {
            return Ok(_StudentService.Delete(id));
        }
    }
}

using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.GeniricInterface;
using School_DAL.Database;
using School_DAL.Model;
using School_BL.Services;
using School.ViewModel;
using AutoMapper;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;

        IStudentService _StudentService;
        public StudentController(IStudentService studentService , IMapper mapper) 
        {
            _StudentService = studentService;
            _mapper = mapper;
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Student student)
        {
           
            if (_StudentService.Add(student))
                return Ok("Scuccessfully added student");
            else
                return StatusCode(400);
        }

        [HttpGet("GetAllStudent")]
        public IActionResult GetStudent()
        {
            var students = _StudentService.GetAll().Select(u=> _mapper.Map<Student>(u));
            if (students !=null)
                return Ok(students);
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

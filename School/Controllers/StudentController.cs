using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.GeniricInterface;
using School_DAL.Database;
using School_DAL.Model;
using School_BL.Services;
using School.ViewModel;
using AutoMapper;
using System.Data;
using School.Response;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IMapper _mapper;

        IDbResponse _dbResponse;


        IStudentService _StudentService;
        public StudentController(IStudentService studentService , IMapper mapper , IDbResponse dbResponse) 
        {
            _StudentService = studentService;
            _mapper = mapper;
            _dbResponse = dbResponse;
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Student student)
        {


            if (_StudentService.Add(student))
            {
                _dbResponse.Status = true;
                _dbResponse.Message = "Scuccessfully added student";
                return Ok(_dbResponse);

            }
            else
                return StatusCode(400);
        }

        [HttpGet("GetAllStudent")]
        public IActionResult GetStudent()
        {
            var students = _StudentService.GetAll().Select(u=> _mapper.Map<StudentViewModel>(u));
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

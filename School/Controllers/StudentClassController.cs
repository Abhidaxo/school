using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.GeniricInterface;
using School_BL.Services;
using School_DAL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {
        IStudentClassService _studentClassService;
        IServiceProvider _serviceProvider;
        public StudentClassController(IStudentClassService studentclassService,IServiceProvider serviceProvider) 
        { 
            _studentClassService = studentclassService;
            _serviceProvider = serviceProvider;
        }


        [HttpPost("AddStudentClass")]
        public IActionResult AddStudentClass(int Roll_no ,int Class_Id)
        {
            StudentClass studentClass = new StudentClass();
            studentClass.Roll_No = Roll_no;
            studentClass.Class_Id = Class_Id;
            if (_studentClassService.Add(studentClass))
                return StatusCode(200);
            else
                return StatusCode(400);
        }

        [HttpGet("GetStudentClass")]
        public IActionResult GetStudentClass()
        {
            var stud = (_studentClassService.GetAll());
            if (stud.Any())
                return StatusCode(200,stud);
            else
                return StatusCode(400);

        }

        [HttpGet("{id}")]
        public IActionResult GetStudentClassById(int Id)
        {
            var id = (_studentClassService.GetById(Id));

            if (id == null)
                return StatusCode(400);
            else
                return StatusCode(200, id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentClass(int Id)
        {
            if (_studentClassService.Delete(Id))
                return StatusCode(200,_studentClassService.Delete(Id));
            else
                return StatusCode(400);

        }
    }
}

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
            return Ok(_studentClassService.Add(studentClass));
        }

        [HttpGet("GetStudentClass")]
        public IActionResult GetStudentClass()
        {
            return Ok(_studentClassService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentClassById(int Id)
        {
            var students = _serviceProvider.GetService<IStudentService>();
            var classs  = _serviceProvider.GetService<IClassService>();

            var result = new 
            {

            };
            return Ok(_studentClassService.GetById(Id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentClass(int Id)
        {
            return Ok(_studentClassService.Delete(Id));
        }
    }
}

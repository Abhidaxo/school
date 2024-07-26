using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using School.UserData;
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
        ILifetimeScope _lifetimeScope;
        public StudentClassController(IStudentClassService studentclassService,IServiceProvider serviceProvider,IUserConnectionData userConnection) 
        { 
            _studentClassService = studentclassService;
            _serviceProvider = serviceProvider;
            _lifetimeScope = userConnection.Scope;
        }


        [HttpPost("AddStudentClass")]
        public IActionResult AddStudentClass(int Roll_no ,int Class_Id)
        {
            using (_lifetimeScope.BeginLifetimeScope())
            {
                var StudentService = _lifetimeScope.Resolve<IStudentService>();
                var ClassServive = _lifetimeScope.Resolve<IClassService>();
                bool stu = StudentService.GetById(Class_Id) != null;
                bool cls = ClassServive.GetById(Class_Id) != null;
                if (stu && cls)
                {
                    StudentClass studentClass = new StudentClass();
                    studentClass.Roll_No = Roll_no;
                    studentClass.Class_Id = Class_Id;

                    if (_studentClassService.Add(studentClass))
                        return StatusCode(200);
                    else
                        return StatusCode(400);
                }
                else
                    return BadRequest("There is no class or student in this id ");
            }
                
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

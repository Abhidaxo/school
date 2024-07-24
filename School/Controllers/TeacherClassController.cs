using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.GeniricInterface;
using School_DAL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherClassController : ControllerBase
    {
        ITeacherClass _teacherClassService;
        public TeacherClassController(ITeacherClass teacherclassService)
        {
            _teacherClassService = teacherclassService;
        }


        [HttpPost]
        public IActionResult AddTeacherClass(int Teacher_Id, int Class_Id)
        {
            TeacherClass teacherClass = new TeacherClass();
            teacherClass.Teacher_Id = Teacher_Id;
            teacherClass.Class_Id = Class_Id;
            return Ok(_teacherClassService.Add(teacherClass));
        }

        [HttpGet]
        public IActionResult GetTeacherClass()
        {
            return Ok(_teacherClassService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherClassById(int Id)
        {
            return Ok(_teacherClassService.GetById(Id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacherClass(int Id)
        {
            return Ok(_teacherClassService.Delete(Id));
        }
    }
}

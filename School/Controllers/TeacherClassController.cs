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
    public class TeacherClassController : ControllerBase
    {
        ITeacherClassService _teacherClassService;
        public TeacherClassController(ITeacherClassService teacherclassService)
        {
            _teacherClassService = teacherclassService;
        }


        [HttpPost("AddTeacherClass")]
        public IActionResult AddTeacherClass(int Teacher_Id, int Class_Id)
        {
            TeacherClass teacherClass = new TeacherClass();
            teacherClass.Teacher_Id = Teacher_Id;
            teacherClass.Class_Id = Class_Id;
            return Ok(_teacherClassService.Add(teacherClass));
        }

        [HttpGet("AddTeacherClass")]
        public IActionResult GetTeacherClass()
        {
            return Ok(_teacherClassService.GetAll());
        }

        [HttpGet("AddTeacherClass/{id}")]
        public IActionResult GetTeacherClassById(int Id)
        {
            return Ok(_teacherClassService.GetById(Id));
        }

        [HttpDelete("AddTeacherClass/{id}")]
        public IActionResult DeleteTeacherClass(int Id)
        {
            return Ok(_teacherClassService.Delete(Id));
        }
    }
}

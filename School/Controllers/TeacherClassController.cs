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
            if (_teacherClassService.Add(teacherClass))
                return Ok("Successfully added");
            else
                return BadRequest();
        }

        [HttpGet("GetAllTeacherClass")]
        public IActionResult GetTeacherClass()
        {
            try
            {
            return Ok(_teacherClassService.GetAll());

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTeacherClassById/{id}")]
        public IActionResult GetTeacherClassById(int Id)
        {
            var teacher = (_teacherClassService.GetById(Id));
            if( teacher== null)
             return StatusCode(400);
            else
             return Ok(teacher);
        }

        [HttpDelete("DeleteTeacherClassById/{id}")]
        public IActionResult DeleteTeacherClass(int Id)
        {
            if (_teacherClassService.Delete(Id))
                return Ok(_teacherClassService.Delete(Id));
            else
                return StatusCode(400);
        }
    }
}

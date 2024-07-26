using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.UserData;
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
        ILifetimeScope Scope;
        ITeacherClassService _teacherClassService;
        public TeacherClassController(ITeacherClassService teacherclassService,IUserConnectionData userConnection)
        {
            _teacherClassService = teacherclassService;
            Scope = userConnection.Scope;
        }


        [HttpPost("AddTeacherClass")]
        public IActionResult AddTeacherClass(int Teacher_Id, int Class_Id)
        {
            using (Scope.BeginLifetimeScope())
            {
                var teacheService = Scope.Resolve<ITeacherService>();
                var ClassService = Scope.Resolve<IClassService>();
                bool hasTeacher = teacheService.GetById(Teacher_Id)!=null;
                bool hasClass = ClassService.GetById(Class_Id)!=null;
                if (hasTeacher && hasClass)
                {
                    TeacherClass teacherClass = new TeacherClass();
                    teacherClass.Teacher_Id = Teacher_Id;
                    teacherClass.Class_Id = Class_Id;
                    if (_teacherClassService.Add(teacherClass))
                        return Ok("Successfully added");
                    else
                        return BadRequest();
                }
                else
                return BadRequest("There is no teacher or class for given id");
            }
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

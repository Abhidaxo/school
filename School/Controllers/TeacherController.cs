using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.GeniricInterface;
using School_BL.Services;
using School_DAL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("AddTeacherClass")]
        public IActionResult AddTecher(string name,string subject)
        {
            Teacher teacher = new Teacher();
            teacher.Teacher_Name = name;
            teacher.Teacher_Subject = subject;
            return Ok(new{ Success= _teacherService.Add(teacher),data=teacher});
        }

        [HttpGet("GetTeacherClass")] 
        public IActionResult GetTecher()
        {
            return Ok(_teacherService.GetAll());    
        }

        [HttpGet("GetTecherById/{id}")]
        public IActionResult GetTecherById(int id)
        {
            return Ok(_teacherService.GetById(id));
        }

        [HttpDelete("DeleteTecherById/{id}")]
        public IActionResult DeleteGetById(int id)
        {
            return Ok(_teacherService.Delete(id));
        }


    }
}

using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.UserData;
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
        ILifetimeScope Scope;

        IMapper _mapper;
        public TeacherController(ITeacherService teacherService , IMapper mapper,IUserConnectionData userConnection)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            Scope = userConnection.Scope;
        }

        [HttpPost("AddTeacherClass")]
        public IActionResult AddTecher(Teacher teacher)
        {

            if (_teacherService.Add(teacher))
                 return StatusCode(200);
            else
                 return StatusCode(400);
        }

        [HttpGet("GetTeacherClass")] 
        public IActionResult GetTecher()
        {
            var tchr = _teacherService.GetAll().Select(x => _mapper.Map<Teacher>(x)).ToList();
          
            return Ok(tchr);    
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

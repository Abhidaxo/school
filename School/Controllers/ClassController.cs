using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Response;
using School.UserData;
using School_BL.GeniricInterface;
using School_BL.Services;
using School_DAL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IDbResponse _dbResponse;

        IMapper mapper;

        IClassService _classService;
        ILifetimeScope Scope { get; set; }

        public ClassController(IClassService classService,IUserConnectionData userConnectionData,IDbResponse dbResponse ,IMapper mapper)
        {
            _classService = classService;
            Scope = userConnectionData.Scope;
            _dbResponse = dbResponse;
        }

        [HttpPost("AddClass")]
        public IActionResult AddClass(Class classs)
        {
            
            if (_classService.Add(classs))
            {
                _dbResponse.Status = true;
                _dbResponse.Message = "Class successfully added";

                return Ok(_dbResponse);
            }
            else
                return StatusCode(400, "Something went Wrong");
        }
        //Example for ILifeTimeScrope
        [HttpGet("GetAll")]
        public IActionResult GetAllData()
        {
            using(Scope.BeginLifetimeScope())
            {
                var teacher = Scope.Resolve<ITeacherService>();
                return Ok(teacher.GetAll());
            }
        }

        [HttpGet("GetAllClass")]
        public IActionResult GetClass()
        {
            var Stud = _classService.GetAll().Select(u=>u.Class_Id);
            try
            {
                _dbResponse.Status = true;
                _dbResponse.Message = "Request Successfully";
                _dbResponse.Data = _classService.GetAll();
                return Ok(_dbResponse);

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetClassById/{id}")]
        public IActionResult GetClassById(int id)
        {
            var classs = _classService.GetById(id);
            if (classs == null)
                return StatusCode(404);
            else
                return StatusCode(200,classs);
        }

        [HttpDelete("DeleteClass/{id}")]
        public IActionResult DeleteById(int id)
        {
            if (_classService.Delete(id))
                return StatusCode(200, _classService.Delete(id));
            else

                return StatusCode(400);
        }
    }
}

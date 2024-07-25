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
    public class ClassController : ControllerBase
    {
        IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost("AddClass")]
        public IActionResult AddClass(string name)
        {
            Class classs = new Class();
            classs.Class_Name = name;
            if (_classService.Add(classs))
                return StatusCode(201, "Class successfully added");
            else
                return StatusCode(400, "Something went Wrong");
        }

        [HttpGet("GetAllClass")]
        public IActionResult GetClass()
        {
            try
            {
            return StatusCode(200,_classService.GetAll());

            }catch(Exception ex)
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

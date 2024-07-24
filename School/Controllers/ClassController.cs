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
            return Ok(_classService.Add(classs));
        }

        [HttpGet("GetAllClass")]
        public IActionResult GetClass()
        {
            return Ok(_classService.GetAll());

        }

        [HttpGet("GetClassById/{id}")]
        public IActionResult GetClassById(int id)
        {
            return Ok(_classService.GetById(id));
        }

        [HttpDelete("DeleteClass/{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_classService.Delete(id));
        }
    }
}

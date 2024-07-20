using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using School_BL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Class_controller : ControllerBase
    {
        private readonly string _connectionstring;

        public Class_controller(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("defaultConnnection");

        }

        [HttpPost]

        public IActionResult AddClass(string name)
        {
            Class classs = new Class();
            classs.Class_Name = name;

            SqlRequest<Class> newclass = new SqlRequest<Class>(_connectionstring);
            newclass.Save(classs);
            return Ok();
        }

        [HttpGet]

        public IActionResult GetClass()
        {
            SqlRequest<Class> req =  new SqlRequest<Class>(_connectionstring);
            IEnumerable<Class> cls =  req.GetAll();
            return Ok(cls);

        }

        [HttpGet("class/{id}")]

        public IActionResult GetClassById(int id)
        {
            SqlRequest<Class> req = new SqlRequest<Class>(_connectionstring);
            var data = req.GetbyId(id);
            return Ok(data);

        }

        [HttpDelete("class/{id}")]

        public IActionResult DeleteById(int id)
        {
            SqlRequest<Class> req = new SqlRequest<Class>(_connectionstring);
            req.DeleteId(id);
            return Ok();

        }
    }
}

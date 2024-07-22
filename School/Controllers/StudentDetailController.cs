using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.Services;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetAll(StudentDetailsService studentdetail)
        {
            return Ok(studentdetail.getStudentDetails());
        }
        
    }
}

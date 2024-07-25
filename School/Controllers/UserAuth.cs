using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.UserData;
using School_BL.Services;
using School_DAL.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuth : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(JWTTokenCreate tokenCreate, UserAuthService userAuth, string Admin_Id,string password)
        {
            
            
             Admin admin = userAuth.GetUser(Admin_Id);
            if(admin == null )
            {
                return Unauthorized("No user found");
            }
            else if(password == admin.Password && admin.Admin_Id ==  Admin_Id)
            {
                return Ok(tokenCreate.CreateJWTToken(Admin_Id));
            }
            return Unauthorized("Check your id or password");
        }

    }
}

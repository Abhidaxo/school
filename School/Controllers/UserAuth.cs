using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School_BL.Services;
using School_DAL.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuth : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(IConfiguration configuration, UserAuthService userAuth, string Admin_Id,string password)
        {
            //Admin admin = new Admin();
            //admin.Admin_Id = Admin_Id;
             Admin admin = userAuth.GetUser(Admin_Id);
            if(admin == null )
            {
                return Unauthorized("No user found");
            }
            else if(password == admin.Password && admin.Admin_Id ==  Admin_Id)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(configuration["Jwt:Issuer"],
                  configuration["Jwt:Audience"],
                  null,
                  expires: DateTime.UtcNow.AddMinutes(3),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
                return Ok(token);
            }
            return Unauthorized("Check your id or password");
        }

    }
}

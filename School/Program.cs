
using FirebirdSql.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using School_DAL.Database;
using School_BL.Repositories;
using School_BL.Services;
using School_DAL.Model;
using System.Text;
using School.Middleware;

namespace School
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IGenericRepositoryService<Student>,StudentService>();
            builder.Services.AddScoped<IGenericRepositoryService<Teacher>,TeacherService>();
            builder.Services.AddScoped<IGenericRepositoryService<Class>,ClassService>();
            builder.Services.AddScoped<IGenericRepositoryService<StudentClass>,StudentClassService>();
            builder.Services.AddScoped<IGenericRepositoryService<TeacherClass>,TeacherClassService>();
            builder.Services.AddScoped<UserAuthService>();
            builder.Services.AddScoped<StudentDetailsService>();

            //JWT Token
            var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
            var jwtAudience = builder.Configuration.GetSection("Jwt:Audience").Get<string>();
            var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtIssuer,
                     ValidAudience = jwtAudience,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                 };
             });
            



            var app = builder.Build();

            Create_Migration obj = new Create_Migration("Server=DESKTOP-MDKBS0M;port=3306;Database=SchoolTestDb;User=root;Password=userpass;");
            obj.Start_Migration();

          //  app.UseMiddleware<loggerMiddleware>();
            app.UseMiddleware<JWTokenmiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

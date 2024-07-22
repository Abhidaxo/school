
using FirebirdSql.Data.Services;
using School_BL.Database;
using School_BL.Repositories;
using School_BL.Services;
using School_DAL.Model;

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

            var app = builder.Build();

            Create_Migration obj = new Create_Migration("Server=DESKTOP-MDKBS0M;port=3306;Database=SchoolTestDb;User=root;Password=userpass;");
            obj.Start_Migration();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

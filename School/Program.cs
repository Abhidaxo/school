using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using School_Bl.DefaulModules;
using School.Middleware;
using School_BL.GeniricInterface;
using School_BL.Services;
using School_DAL.Migrations;
using School_DAL.Model;
using System.Text;
using School_BL;
using System.Data;
using School.UserData;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using School_DAL.Validator;
using Autofac;
using Microsoft.AspNetCore.SignalR;
using Autofac.Extensions.DependencyInjection;
using School.Response;
using Autofac.Core;
using FluentValidation;

namespace School
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            LoadStaticVariables();
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterType<UserConnectionData>().As<IUserConnectionData>().InstancePerLifetimeScope();
            });


            builder.Services.AddScoped<IStudentService,StudentService>();
            builder.Services.AddScoped<ITeacherService,TeacherService>();
            builder.Services.AddScoped<IClassService,ClassService>();
            builder.Services.AddScoped<IStudentClassService,StudentClassService>();
            builder.Services.AddScoped<ITeacherClassService, TeacherClassService>();
            builder.Services.AddScoped<IDbConnection>(c=>new DbConnect(DefaultValues.ConnectionString)._connection);
            builder.Services.AddScoped<IDbResponse,DbResponse>();
            builder.Services.AddAutoMapper(typeof(Mapper));
            builder.Services.AddScoped<JWTTokenCreate>();
            builder.Services.AddScoped<UserAuthService>();
            builder.Services.AddScoped<StudentDetailsService>();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<StudentValidator>();

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

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });


            var app = builder.Build();

            //Create_Migration obj = new Create_Migration(DefaultValues.ConnectionString);
            //obj.Start_Migration();

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

        private static void LoadStaticVariables()
        {
            IConfigurationRoot MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            DefaultValues.ConnectionString = MyConfig.GetValue<string>("ConnectionStrings:Defaultconnection");

        }
    }
}

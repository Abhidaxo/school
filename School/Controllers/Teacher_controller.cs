﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_BL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teacher_controller : ControllerBase
    {
        IGenericRepositoryService<Teacher> _teacherService;
        public Teacher_controller(IGenericRepositoryService<Teacher> teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public IActionResult AddTecher(string name,string subject)
        {
            Teacher teacher = new Teacher();
            teacher.Teacher_Name = name;
            teacher.Teacher_Subject = subject;
            return Ok(_teacherService.Add(teacher));
        }

        [HttpGet] 
        public IActionResult GetTecher()
        {
            return Ok(_teacherService.GetAll());    
        }

        [HttpGet("teacher/{id}")]
        public IActionResult GetTecherById(int id)
        {
            return Ok(_teacherService.GetById(id));
        }

        [HttpDelete("teacher/{id}")]
        public IActionResult DeleteGetById(int id)
        {
            return Ok(_teacherService.Delete(id));
        }


    }
}

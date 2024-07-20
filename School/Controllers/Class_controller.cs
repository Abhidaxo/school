﻿using Microsoft.AspNetCore.Mvc;
using School_BL.Database;
using School_DAL.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Class_controller : ControllerBase
    {
        IGenericRepositoryService<Class> _classService;

        public Class_controller(IGenericRepositoryService<Class> classService)
        {
            _classService = classService;
        }

        [HttpPost]
        public IActionResult AddClass(string name)
        {
            Class classs = new Class();
            classs.Class_Name = name;
            return Ok(_classService.Add(classs));
        }

        [HttpGet]
        public IActionResult GetClass()
        {
            return Ok(_classService.GetAll());

        }

        [HttpGet("class/{id}")]
        public IActionResult GetClassById(int id)
        {
            return Ok(_classService.GetById(id));
        }

        [HttpDelete("class/{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_classService.Delete(id));
        }
    }
}

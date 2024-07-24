﻿using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_BL.Repositories;
using School_DAL.Model;
using System.Configuration;
using School_BL.GeniricInterface;

namespace School_BL.Services
{

    public class TeacherService : ITeacher
    {
        private readonly string _ConnectionString;
        public TeacherService(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Teacher> GetAll()
        {
            TeacherRepository repo = new TeacherRepository(_ConnectionString);
            return repo.GetAll().ToList();
        }

        public Teacher GetById(int id)
        {
            TeacherRepository repo = new TeacherRepository(_ConnectionString);
            return repo.GetbyId(id);
        }

        public bool Add(Teacher teacher)
        {
            TeacherRepository repo = new TeacherRepository(_ConnectionString);
            return repo.Save(teacher);
        }

        public bool Delete(int id)
        {
            TeacherRepository repo = new TeacherRepository(_ConnectionString);
            return repo.DeleteId(id);
        }
    }
}

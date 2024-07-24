using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_BL.Repositories;
using School_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_BL.GeniricInterface;

namespace School_BL.Services
{
    public class TeacherClassService : ITeacherClass

    {

        private readonly string _ConnectionString;

        public TeacherClassService(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<TeacherClass> GetAll()
        {
            TeacherClassRepository repo = new TeacherClassRepository(_ConnectionString);
            return repo.GetAll().ToList();
        }

        public TeacherClass GetById(int id)
        {
            TeacherClassRepository repo = new TeacherClassRepository(_ConnectionString);
            return repo.GetbyId(id);
        }

        public bool Add(TeacherClass clas)
        {
            TeacherClassRepository repo = new TeacherClassRepository(_ConnectionString);
            return repo.Save(clas);
        }

        public bool Delete(int id)
        {
            TeacherClassRepository repo = new TeacherClassRepository(_ConnectionString);
            return repo.DeleteId(id);
        }
    }
}

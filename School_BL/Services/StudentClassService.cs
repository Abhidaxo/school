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
    public class StudentClassService : IStudentClass
    {
        private readonly string _ConnectionString;

        public StudentClassService(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<StudentClass> GetAll()
        {
            StudentClassRepository repo = new StudentClassRepository(_ConnectionString);
            return repo.GetAll().ToList();
        }

        public StudentClass GetById(int id)
        {
            StudentClassRepository repo = new StudentClassRepository(_ConnectionString);
            return repo.GetbyId(id);
        }

        public bool Add(StudentClass clas)
        {
            StudentClassRepository repo = new StudentClassRepository(_ConnectionString);
            return repo.Save(clas);
        }

        public bool Delete(int id)
        {
            StudentClassRepository repo = new StudentClassRepository(_ConnectionString);
            return repo.DeleteId(id);
        }
    }
}

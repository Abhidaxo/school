
using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_BL.Repositories;
using School_DAL.Model;
using School_BL.GeniricInterface;

namespace School_BL.Services
{
    public class StudentService : IStudent
    {
        private readonly string _ConnectionString;
        public StudentService(IConfiguration configuration) 
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Student> GetAll()
        {
            StudentRepository repo = new StudentRepository(_ConnectionString);
            return repo.GetAll().ToList();
        }

        public Student GetById(int id)
        {
            StudentRepository repo = new StudentRepository(_ConnectionString);
            return repo.GetbyId(id);
        }

        public bool Add(Student student)
        {
            StudentRepository repo = new StudentRepository(_ConnectionString);
            return repo.Save(student);
        }

        public bool Delete(int id)
        {
            StudentRepository repo = new StudentRepository(_ConnectionString);
            return repo.DeleteId(id);
        }
    }
}



using Microsoft.Extensions.Configuration;
using School_BL.Database;
using School_BL.Repositories;
using School_DAL.Model;
using System.Configuration;

namespace School_BL.Services
{
     public class ClassService : IGenericRepositoryService<Class>
    {
        private readonly string _ConnectionString;
        public ClassService(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Class> GetAll()
        {
            ClassRepository repo = new ClassRepository(_ConnectionString);
            return repo.GetAll().ToList();
        }

        public Class GetById(int id)
        {
            ClassRepository repo = new ClassRepository(_ConnectionString);
            return repo.GetbyId(id);
        }

        public bool Add(Class clas)
        {
            ClassRepository repo = new ClassRepository(_ConnectionString);
            return repo.Save(clas);
        }

        public bool Delete(int id)
        {
            ClassRepository repo = new ClassRepository(_ConnectionString);
            return repo.DeleteId(id);
        }
    }
}

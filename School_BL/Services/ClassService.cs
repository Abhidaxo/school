

using School_BL.Database;
using School_BL.Repositories;
using School_DAL.Model;

namespace School_BL.Services
{
     public class ClassService : IGenericRepositoryService<Class>
    {
        private readonly string _ConnectionString;
        public ClassService(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
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

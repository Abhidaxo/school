

namespace School_DAL.Database
{

    public interface IGenericRepositoryService<T>
    {
        T GetById(int id);
        List<T> GetAll();
        bool Add(T entity);
        bool Delete(int id);
    }

}

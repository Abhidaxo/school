

namespace School_BL.GeniricInterface
{

    public interface IGenericRepositoryService<T>
    {
        T GetById(int id);
        List<T> GetAll();
        //bool IsNew(T entity);
        bool Add(T entity);
        bool Delete(int id);
    }

}

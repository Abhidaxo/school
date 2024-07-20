using School_BL.Database;
using School_DAL.Model;

namespace School_BL.Repositories
{
    public class ClassRepository : SqlRequest<Class>
    {
        public ClassRepository(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}

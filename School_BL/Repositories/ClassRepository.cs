using School_DAL.Database;
using School_DAL.Model;

namespace School_BL.Repositories
{
    public class ClassRepository : GenricSqlRequest<Class>
    {
        public ClassRepository(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}

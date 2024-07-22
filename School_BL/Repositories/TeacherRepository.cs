using School_DAL.Database;
using School_DAL.Model;

namespace School_BL.Repositories
{
    public class TeacherRepository : GenricSqlRequest<Teacher>
    {
        public TeacherRepository(string ConnectionString):base(ConnectionString) { }
    }
}

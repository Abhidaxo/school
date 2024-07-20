using School_BL.Database;
using School_DAL.Model;

namespace School_BL.Repositories
{
    public class TeacherRepository : SqlRequest<Teacher>
    {
        public TeacherRepository(string ConnectionString):base(ConnectionString) { }
    }
}

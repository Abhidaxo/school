using School_DAL.Database;
using School_DAL.Model;

namespace School_BL.Repositories
{
    public class StudentRepository : GenricSqlRequest<Student>
    {
        public StudentRepository(string ConnectionString): base(ConnectionString) { }
    }
}

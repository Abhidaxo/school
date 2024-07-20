using School_BL.Database;
using School_DAL.Model;

namespace School_BL.Repositories
{
    public class StudentRepository : SqlRequest<Student>
    {
        public StudentRepository(string ConnectionString): base(ConnectionString) { }
    }
}

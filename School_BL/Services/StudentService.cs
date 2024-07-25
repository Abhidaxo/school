
using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using School_BL.GeniricInterface;

namespace School_BL.Services
{
    public class StudentService : GenricSqlRequest<Student>, IStudentService
    {
      
        public StudentService(IDbConnect dbConnect) : base(dbConnect)
        {
        }

       
    }
}


using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using School_BL.GeniricInterface;

namespace School_BL.Services
{
    public class StudentService : GenricSqlRequest<Student>
    {
        //private readonly string _ConnectionString;

        //public GenricSqlRequest<Student> _StudentReq;
        public StudentService(IConfiguration configuration) : base(configuration.GetConnectionString("Defaultconnection"))
        {
        }

       
    }
}

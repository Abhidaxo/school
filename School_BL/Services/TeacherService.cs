using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using System.Configuration;
using School_BL.GeniricInterface;

namespace School_BL.Services
{

    public class TeacherService : GenricSqlRequest<Teacher>
    {
        //private readonly string _ConnectionString;
        //public GenricSqlRequest<Teacher> _TeacherReq;
        public TeacherService(IConfiguration configuration) : base(configuration.GetConnectionString("Defaultconnection"))
        {

        }
    }
}

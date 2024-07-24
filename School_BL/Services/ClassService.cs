

using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using System.Configuration;
using School_BL.GeniricInterface;

namespace School_BL.Services
{
    public class ClassService : GenricSqlRequest<Class>
    {
        public ClassService(IConfiguration configuration) : base(configuration.GetConnectionString("Defaultconnection"))
        {

        }
    }
}

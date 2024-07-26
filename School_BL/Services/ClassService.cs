

using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using System.Configuration;
using School_BL.GeniricInterface;
using System.Data;
using School.UserData;

namespace School_BL.Services
{
    public class ClassService : GenricSqlRequest<Class>,IClassService
    {
        public ClassService(IUserConnectionData dbConnect) : base(dbConnect) 
        {

        }
    }
}

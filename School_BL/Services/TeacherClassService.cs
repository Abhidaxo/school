using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_BL.GeniricInterface;

namespace School_BL.Services
{
    public class TeacherClassService : GenricSqlRequest<TeacherClass>

    {

        //private readonly string _ConnectionString;

        //public GenricSqlRequest<TeacherClass> _TeacherClassReq;

        public TeacherClassService(IConfiguration configuration) : base(configuration.GetConnectionString("Defaultconnection"))
        {

        }

     
    }
}

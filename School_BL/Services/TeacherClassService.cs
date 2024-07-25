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
    public class TeacherClassService : GenricSqlRequest<TeacherClass>,ITeacherClassService

    {

        

        public TeacherClassService(IDbConnect dbConnect) : base(dbConnect)
        {

        }

     
    }
}

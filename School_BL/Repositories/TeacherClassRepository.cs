using School_DAL.Database;
using School_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_BL.Repositories
{
    public class TeacherClassRepository : GenricSqlRequest<TeacherClass>
    {
        public TeacherClassRepository(string connectionString) : base(connectionString) { }
    }
}

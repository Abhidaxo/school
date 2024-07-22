using School_BL.Database;
using School_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_BL.Repositories
{
    public class StudentClassRepository : SqlRequest<StudentClass>
    {
        public StudentClassRepository(string ConnectionString): base(ConnectionString) { }
    }
}

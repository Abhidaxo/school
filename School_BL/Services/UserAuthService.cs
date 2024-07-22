using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_BL.Services
{
    public class UserAuthService
    {
        private readonly string _ConnectionString;
        public UserAuthService(IConfiguration configuration) 
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public Admin GetUser(string Admin_Id)
        {
            connect Connection = new connect(_ConnectionString);
            string sql = "select * from Admin where Admin_Id = @Admin_Id";
            return Connection._connection.QueryFirstOrDefault<Admin>(sql,new { Admin_Id=Admin_Id});
        }
    }
}

using Microsoft.Extensions.Configuration;
using School_DAL.Database;
using School_DAL.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using School.UserData;

namespace School_BL.Services
{
    public class UserAuthService : GenricSqlRequest<Admin>
    {
        IDbConnection _dbConnection;
        public UserAuthService(IUserConnectionData dbConnect) : base(dbConnect)
        {
            _dbConnection = dbConnect.Connection;
        }
        public Admin GetUser(string Admin_Id)
        {
            string sql = "select * from Admin where Admin_Id = @Admin_Id";
            return _dbConnection.QueryFirstOrDefault<Admin>(sql,new { Admin_Id=Admin_Id});
        }
    }
}

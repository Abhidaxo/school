using MySql.Data.MySqlClient;
using School_Bl.DefaulModules;
using School_BL.GeniricInterface;
using System.Data;
namespace School_BL
{
    public class DbConnect : IDbConnect
    {
        public IDbConnection _connection;
        public DbConnect()
        {
            _connection = new MySqlConnection(DefaultValues.ConnectionString);
        }

        public IDbConnection CreateDbConnection()
        {
            return _connection;
        }
    }
}
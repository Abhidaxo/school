using MySql.Data.MySqlClient;
using System.Data;
namespace School_BL
{
    public class DbConnect : IDbConnect
    {
        public IDbConnection _connection;
        public DbConnect(string ConnectionString)
        {
            _connection = new MySqlConnection(ConnectionString);
        }

        public IDbConnection CreateDbConnection()
        {
            return _connection;
        }
    }
}
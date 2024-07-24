using MySql.Data.MySqlClient;
namespace School_DAL.Database
{
    public class connect
    {
        public MySqlConnection _connection;
        public connect(string ConnectionString)
        {
            _connection = new MySqlConnection(ConnectionString);
        }
        public MySqlConnection GetConnection()
        {
            
            return _connection;
        }
    }
}
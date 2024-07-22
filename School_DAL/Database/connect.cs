using MySql.Data.MySqlClient;

namespace School_DAL.Database
{
    public class connect
    {
        public readonly MySqlConnection _connection;
        public connect(string ConnectionString)
        {
            _connection = new MySqlConnection(ConnectionString);
        }
    }
}
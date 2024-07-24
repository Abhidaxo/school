using MySql.Data.MySqlClient;
namespace School_DAL.Database
{
    public class connect
    {
        public readonly MySqlConnection _connection;
        public string _ConnectionString { get; set; }
        public connect(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            _connection = new MySqlConnection(_ConnectionString);
        }
    }
}
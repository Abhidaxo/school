using MySql.Data.MySqlClient;
using School_Bl.DefaulModules;
using School_BL.GeniricInterface;
namespace School_DAL.Database
{
    public class connect
    {
        public MySqlConnection _connection;
        public connect()
        {
            _connection = new MySqlConnection(DefaultValues.ConnectionString);
        }
    }
}
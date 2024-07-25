using System.Data;

namespace School.UserData
{
    public class UserConnectionData : IUserConnectionData
    {
        private IDbConnection _connection;
        public UserConnectionData(IDbConnection dbConnection) {
            _connection = dbConnection;
        }
        public  string username { get; set; } = string.Empty;
        public  string jti { get; set; } = string.Empty;

        public  string Aud { get; set; } = string.Empty ;

        public  string Iss { get; set; } = string.Empty;

        public  string exp { get; set; } = string.Empty;

        public IDbConnection Connection => _connection;
    }
}

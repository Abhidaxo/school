using Autofac;
using System.Data;

namespace School.UserData
{
    public interface IUserConnectionData
    {
        IDbConnection Connection { get; }
        public string username { get; set; }
        public string jti { get; set; }

        public string Aud { get; set; } 

        public string Iss { get; set; }

        public string exp { get; set; }

        public ILifetimeScope Scope { get; set; }
    }
}

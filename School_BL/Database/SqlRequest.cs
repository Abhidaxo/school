using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace School_BL.Database
{
    public class SqlRequest<T> : connect
    {
       
        public SqlRequest(string ConnectionString) : base(ConnectionString)
        {

        }
        public IEnumerable<T> GetAll()
        {
            using(_connection)
            {

            IEnumerable<T> TableDatas;
            string sql = $"SELECT * FROM {typeof(T)}";
            TableDatas = _connection.Query<T>(sql);
            return TableDatas; 
            }
        }

        public void Save(T data)
        {
            using(_connection)
            {
                string sql = $"INSERT INTO {typeof(T).Name}({GetColumns<T>()}) VALUES(@{GetPropValues<T>()})";
                Console.WriteLine(sql);
                _connection.Execute(sql, data);
            }
        }

        public string GetColumns<T>()
        {
            var type = typeof(T);
            var typeProps = type.GetProperties().Select(e=> e.Name).ToList();
            typeProps.RemoveAt(0);
            return string.Join(", ", typeProps);
        }

        public string GetPropValues<T>()
        {
            var type = typeof(T);
            var typeProps = type.GetProperties().Select(e => e.Name).ToList();
            typeProps.RemoveAt(0);
            return string.Join(" ,@",typeProps);
        }
    }
}

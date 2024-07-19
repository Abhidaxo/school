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
            string sql = $"SELECT * FROM {typeof(T).Name}";
            TableDatas = _connection.Query<T>(sql);
            return TableDatas; 
            }
        }

        public void Save(T data)
        {
            using(_connection)
            {
                List<string> protypes = GetPropList<T>();
                protypes.RemoveAt(0);
                string sql = $"INSERT INTO {typeof(T).Name}({string.Join(",",protypes)}) VALUES(@{string.Join(",@",protypes)})";
                Console.WriteLine(sql);
                _connection.Execute(sql, data);
            }
        }

        public List<string> GetPropList<T>()
        {
            var type = typeof(T);
            var typeProps = type.GetProperties().Select(e => e.Name).ToList();
            return typeProps;
        }
        public T GetbyId(int id)
        {
            using (_connection)
            {
                var protypes = GetPropList<T>();
                string sql = $"select * from {typeof(T).Name} where {protypes[0]}={id}";
                T data =  _connection.QueryFirstOrDefault<T>(sql);
                return data;
            }
        }
        public void DeleteId(int id)
        {
            using (_connection)
            {
                var protypes = GetPropList<T>();
                string sql = $"delete from  {typeof(T).Name} where {protypes[0]}={id}";
                _connection.Execute(sql);

            }    
        }
    }
}

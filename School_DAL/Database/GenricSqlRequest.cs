using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Database
{
    public class GenricSqlRequest<T> : connect
    {
       
        public GenricSqlRequest(string ConnectionString) : base(ConnectionString)
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

        public bool Save(T data)
        {
            using(_connection)
            {
                string sql = $"INSERT INTO {getTableName()}({getColums()}) VALUES(@{getColumsPros()})";
                Console.WriteLine(sql);
                try
                {
                    _connection.Execute(sql, data);
                    return true;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public T GetbyId(int id)
        {
            using (_connection)
            {
                var protypes = GetPropList();
                string sql = $"select * from {getTableName()} where {protypes[0]}={id}";
                T data =  _connection.QueryFirstOrDefault<T>(sql);
                return data;
            }
        }

        public bool DeleteId(int id)
        {
            using (_connection)
            {
                var protypes = GetPropList();
                string sql = $"delete from  {getTableName()} where {protypes[0]}={id}";
                try
                {
                    _connection.Execute(sql);
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }    
        }

        public string getTableName()
        {
            return typeof(T).Name;
        }

        public List<string> GetPropList()
        {
            var type = typeof(T);
            var typeProps = type.GetProperties().Select(e => e.Name).ToList();
            return typeProps;
        }

        public string getColums()
        {
            List<string> columns = GetPropList();
            columns.RemoveAt(0);
            return string.Join(",", columns);
        }

        public string getColumsPros()
        {
            List<string> columsProps = GetPropList();
            columsProps.RemoveAt(0);
            return string.Join(",@", columsProps);
        }

    }
}

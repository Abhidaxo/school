using Dapper;
using School.UserData;
using School_BL;
using School_BL.GeniricInterface;
using System.Data;

namespace School_DAL.Database
{
    public class GenricSqlRequest<T> : IGenericRepositoryService<T> where T : class
    {
        public string _sql { get; set; }


        IDbConnection _dbConnection;
        public GenricSqlRequest(IUserConnectionData dbConnect)
        {
            _dbConnection = dbConnect.Connection;
        }

        public List<T> GetAll()
        {
            IEnumerable<T> TableDatas;
            string sql = $"SELECT * FROM {typeof(T).Name}";
            TableDatas = _dbConnection.Query<T>(sql);
            return TableDatas.ToList<T>(); 
        }

        public bool Add(T data)
        {
            using(_dbConnection)
            {
                string sql = $"INSERT INTO {getTableName()}({getColums()}) VALUES(@{getColumsPros()})";
      
                try
                {
                    int effecteRows = _dbConnection.Execute(sql, data);
                    if (effecteRows > 0)
                        return true;
                    else
                        return false;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public T GetById(int id)
        {
                var protypes = GetPropList();
                string sql = $"select * from {getTableName()} where {protypes[0]}={id}";
                T data =  _dbConnection.QueryFirstOrDefault<T>(sql);
                return data;
        }

        public bool Delete(int id)
        {
                var protypes = GetPropList();
                string sql = $"delete from  {getTableName()} where {protypes[0]}={id}";
                try
                {
                    int effectedRows = _dbConnection.Execute(sql);
                    if(effectedRows > 0) 
                    return true;
                    else
                        return false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
 
        }

        public List<T> GetAllDatas(string sql)
        {
                return _dbConnection.Query<T>(sql).ToList();
        }

        public T GetData()
        {

            return _dbConnection.QueryFirstOrDefault<T>(_sql);
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

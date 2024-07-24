using Dapper;
using School_BL.GeniricInterface;

namespace School_DAL.Database
{
    public class GenricSqlRequest<T> : connect, IGenericRepositoryService<T> where T : class
    {
        public string _sql { get; set; }

       
        public GenricSqlRequest()
        {
           
        }

        public List<T> GetAll()
        {
            using(_connection)
            {

            IEnumerable<T> TableDatas;
            string sql = $"SELECT * FROM {typeof(T).Name}";
            TableDatas = _connection.Query<T>(sql);
            return TableDatas.ToList<T>(); 
            }
        }

        public bool Add(T data)
        {
            using(_connection)
            {
                string sql = $"INSERT INTO {getTableName()}({getColums()}) VALUES(@{getColumsPros()})";
      
                try
                {
                    int effecteRows = _connection.Execute(sql, data);
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
            using (_connection)
            {
                var protypes = GetPropList();
                string sql = $"select * from {getTableName()} where {protypes[0]}={id}";
                T data =  _connection.QueryFirstOrDefault<T>(sql);
                return data;
            }
        }

        public bool Delete(int id)
        {
            using (_connection)
            {
                var protypes = GetPropList();
                string sql = $"delete from  {getTableName()} where {protypes[0]}={id}";
                try
                {
                    int effectedRows = _connection.Execute(sql);
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
        }

        public List<T> GetAllDatas(string sql)
        {
            using(_connection)
            {
                return _connection.Query<T>(sql).ToList();

            }

        }

        public T GetData()
        {
            using (_connection)
            {
                return _connection.QueryFirstOrDefault<T>(_sql);
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

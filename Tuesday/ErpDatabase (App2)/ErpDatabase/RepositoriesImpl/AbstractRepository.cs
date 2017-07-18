using ErpDatabase.Entities;
using ErpDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.RepositoriesImpl
{
    public abstract class AbstractRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        SqlConnection connection;
        protected abstract string deleteSql();
        protected abstract string updateSql();
        protected abstract string insertSql();
        protected abstract string getOneSql();
        protected abstract string getAllSql();

        public AbstractRepository(SqlConnection connection)
        {
            this.connection = connection;
        }


        private SqlCommand CreateCommand(string sqlText, SqlConnection connection)
        {
            return new SqlCommand(sqlText, connection);
        }

        public void Delete(int id)
        {

            using (var command = CreateCommand(deleteSql(), connection))
            {
                command.Parameters.AddWithValue(@"@id", id);

                command.ExecuteNonQuery();
            }
        }

        public IList<T> GetAll()
        {
            var list = new List<T>();

            using (var command = CreateCommand(getAllSql(), connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(ReaderToEntity(reader));
                    }
                }
            }


            return list;
        }

        public T GetById(int id)
        {

            using (var command = CreateCommand(getOneSql(), connection))
            {
                command.Parameters.AddWithValue(@"@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReaderToEntity(reader);
                    }
                }
            }


            return null;
        }

        public int Insert(T entity)
        {
            if (null == entity)
                throw new ArgumentNullException("entity");


                using (var command = CreateCommand(insertSql(), connection))
                {
                    AddInsertParameters(command, entity);

                    return Convert.ToInt32(command.ExecuteScalar());
                }

        }

        public void Update(T entity)
        {
            if (null == entity)
                throw new ArgumentNullException("entity");


                using (var command = CreateCommand(updateSql(), connection))
                {
                    AddUpdateParameters(command, entity);

                    command.ExecuteNonQuery();
                }

        }

        protected abstract T ReaderToEntity(SqlDataReader reader);
        protected abstract void AddUpdateParameters(SqlCommand command, T entity);
        protected abstract void AddInsertParameters(SqlCommand command, T entity);
    }
}

using ErpDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.RepositoriesImpl
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : IEntity, new()
    {
        protected abstract T ReaderToEntity(SqlDataReader reader);
        public abstract string GetTextSQL();
        public abstract void AddInsertParameter(T elem, SqlCommand command);
        public abstract void Parameter(T elem, SqlCommand command);

        public void Delete(int id)
        {
            
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

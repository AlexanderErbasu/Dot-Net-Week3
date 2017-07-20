using ErpDatabase.Entities;
using ErpDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Ef.RepositoriesImpl
{
    public class EfRepository<T> : IRepository<T>
        where T : class , IEntity, new()
    {
        private DbContext session;

        public EfRepository(DbContext session)
        {
            this.session = session;
        }

        public void Delete(int id)
        {
            session.Set<T>().Remove(new T { Id = id });
        }

        public IList<T> GetAll()
        {
            return session.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return session.Set<T>().SingleOrDefault(a => a.Id == id);
        }

        public int Insert(T entity)
        {
            session.Set<T>().Add(entity);

            return entity.Id;
        }

        public void Update(T entity)
        {
            session.Set<T>().Attach(entity);
        }
    }
}

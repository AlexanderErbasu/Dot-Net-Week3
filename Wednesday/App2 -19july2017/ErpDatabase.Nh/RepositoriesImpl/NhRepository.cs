using ErpDatabase.Entities;
using ErpDatabase.Repositories;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Nh.RepositoriesImpl
{
    public class NhRepository<T> : IRepository<T>
        where T : class , IEntity, new()
    {
        private ISession session;

        public NhRepository(ISession session)
        {
            this.session = session;
        }

        public void Delete(int id)
        {
            var entity = session.Load<T>(id);

            session.Delete(entity);
        }

        public IList<T> GetAll()
        {
            var x = session.Query<T>().ToList();
            

            return x;
        }

        public T GetById(int id)
        {
            return session.Get<T>(id);
        }

        public int Insert(T entity)
        {
            session.Save(entity);

            return entity.Id;
        }

        public void Update(T entity)
        {
            session.Update(entity);
        }
    }
}

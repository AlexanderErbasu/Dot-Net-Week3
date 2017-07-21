using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries;
using NHibernate;
using Countries.Entities;
using NHibernate.Linq;

namespace Countries.Nh.RepositoriesImpl
{
    public class NhRepository<T> : IRepository<T>
       where T : class, IEntity, new()
    {
        private ISession session;

        public NhRepository(ISession session)
        {
            this.session = session;
        }

        public void Delete(string id)
        {
            var entity = session.Load<T>(id);
            session.Flush();
            session.Delete(entity);
        }

        public IList<T> GetAll()
        {
            var x = session.Query<T>().ToList();
            return x;
        }

        public T GetById(string id)
        {
            return session.Get<T>(id);
        }

        public string Insert(T entity)
        {
            session.Save(entity);
            session.Flush();
            return entity.Code;
        }

        public void Update(T entity)
        {
            session.Update(entity);
            session.Flush();
        }
    }
}

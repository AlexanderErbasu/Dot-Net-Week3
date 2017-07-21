using Countries.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Countries.Nh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Tests.nH
{
    public abstract class NhAbstractTest<T> : AbstractTest<T>
                where T : IEntity, new()
    {
        protected ISession session;
        protected ISessionFactory sessionFactory;

        [TestInitialize]
        public void Initialize()
        {
            sessionFactory = new NhConfig(connectionString).Create();
            session = sessionFactory.OpenSession();

            using (var command = session.Connection.CreateCommand())
            {
                command.CommandText = GetCleanupSql();
                command.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            session.Flush();
            session.Dispose();
        }
    }
}

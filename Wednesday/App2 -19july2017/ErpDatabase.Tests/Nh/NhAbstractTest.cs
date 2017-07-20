using ErpDatabase.Entities;
using ErpDatabase.Nh;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace ErpDatabase.Tests
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

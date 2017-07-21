using Countries;
using Countries.Ef;
using Countries.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Countries.Tests.Ef
{
    public abstract class EfAbstractTest<T> : AbstractTest<T>
                where T : IEntity, new()
    {
        protected ErpContext session;

        [TestInitialize]
        public void Initialize()
        {
            /* Create a session and execute a query: */
            session = new ErpContext(connectionString);

            session.Database.ExecuteSqlCommand(GetCleanupSql());
        }

        [TestCleanup]
        public void Cleanup()
        {
            session.Dispose();
        }
    }
}

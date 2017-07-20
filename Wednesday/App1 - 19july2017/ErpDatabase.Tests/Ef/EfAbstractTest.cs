using ErpDatabase.Ef;
using ErpDatabase.Entities;
using ErpDatabase.Nh;
using ErpDatabase.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Tests
{
    public abstract class EfAbstractTest<T>
                where T : IEntity, new()
    {
        protected string connectionString = @"Data Source=(local);Initial Catalog=MagazinOnline;User ID=sa;Password=1234%asd;";

        protected abstract IRepository<T> CreateTarget();
        protected ErpContext session;


        #region test assert and cleanup methods
        //protected abstract void AssertSame(T expected, T actual, bool testId = false);

        [TestInitialize]
        public void Initialize()
        {


            /* Create a session and execute a query: */
            session = new ErpContext(connectionString);

            //    session = new SqlConnection(connectionString);
            //session.Open();

            //using (var command = new SqlCommand(GetCleanupSql(), session))
            //{
            //    command.ExecuteNonQuery();
            //}
        }

        [TestCleanup]
        public void Cleanup()
        {
            session.Dispose();
        }

        //protected abstract string GetCleanupSql();
        #endregion

        //protected abstract T CreateObject();
        //protected abstract void UpdateObject(T entity);

        [TestMethod]
        public void WhenInsertingOneWeCanGetThatObject()
        {
            var target = CreateTarget();

            var actual = target.GetById(1);

            Assert.AreEqual(1, actual.Id);
        }

    }
}

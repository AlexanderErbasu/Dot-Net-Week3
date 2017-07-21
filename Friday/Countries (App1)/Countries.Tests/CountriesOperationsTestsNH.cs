using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Countries.Operations;
using Countries.Parsers;
using Countries.Ef;
using Countries.Ef.RepositoriesImpl;
using Countries.Entities;
using NHibernate;
using Countries.Nh.RepositoriesImpl;
using Countries.Nh;

namespace Countries.Tests
{
    [TestClass]
    public class CountriesOperationsTestsNH
    {
        protected string connectionString = @"Data Source=(local);Initial Catalog=Countries;User ID=sa;Password=1234%asd;";

        private ISession session;
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

        private string GetCleanupSql()
        {
            return "delete from Country";
        }

        [TestCleanup]
        public void Cleanup()
        {
            session.Flush();
            session.Dispose();
        }

        private ICountriesOperations CreateTarget()
        {
            var repo = new NhRepository<Country>(session);
            AddToDatabaseNH db = new AddToDatabaseNH(repo, new CsvCountrieFileParser());
            db.Add(@"Countries.csv");            

            return new NHCountriesOperationsDB(session);
        }

        [TestMethod]
        public void WhenSingleByCodeXXWeGetNull()
        {
            var target = CreateTarget();

            var entity = target.SingleByCode("XX");

            Assert.IsNull(entity);
        }

        [TestMethod]
        public void WhenSingleByCodeROWeGetRomania()
        {
            var target = CreateTarget();

            var entity = target.SingleByCode("RO");

            Assert.IsNotNull(entity);
            Assert.AreEqual("Romania", entity.Nume);
        }

        [TestMethod]
        public void WhenListNameStartsWithZWeGet2()
        {
            var target = CreateTarget();

            var entities = target.ListNameStartsWith("Z");

            Assert.IsNotNull(entities);
            Assert.AreEqual(2, entities.Count);
        }

        [TestMethod]
        public void WhenListNameStartsWithZZWeGet0()
        {
            var target = CreateTarget();

            var entities = target.ListNameStartsWith("ZZ");

            Assert.IsNotNull(entities);
            Assert.AreEqual(0, entities.Count);
        }

        [TestMethod]
        public void GroupByNameFirstLetter()
        {
            var target = CreateTarget();

            var dict = target.GroupByNameFirstLetter();

            Assert.IsNotNull(dict);
            Assert.AreEqual(25, dict.Keys.Count);
        }

        [TestMethod]
        public void WhenAllWithPositionWeGet244()
        {
            var target = CreateTarget();

            var list = target.AllWithPosition();

            Assert.IsNotNull(list);
            Assert.AreEqual(244, list.Count);
        }

        [TestMethod]
        public void WhenSumOfLatitudeForNameStartsWith_Sl_Is()
        {
            var target = CreateTarget();

            var value = target.SumOfLatitudeForNameStartsWith("Sl");

            Assert.AreEqual(94.820267m, value);
        }

        [TestMethod]
        public void WhenMedianOfSumsOfLatAnLongForNameStartsWith_Sl_Is()
        {
            var target = CreateTarget();

            var value = target.MedianOfSumsOfLatAnLongForNameStartsWith("Sl");

            Assert.AreEqual(64.757377m, value);
        }
    }
}

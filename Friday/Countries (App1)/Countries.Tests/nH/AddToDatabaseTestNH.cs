using Countries.Entities;
using Countries.Nh;
using Countries.Parsers;
using NHibernate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Nh.RepositoriesImpl;

namespace Countries.Tests.Ef
{
    [TestClass]
    public class AddToDatabaseTestNH
    {
        protected string connectionString = @"Data Source=(local);Initial Catalog=Countries;User ID=sa;Password=1234%asd;";

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

        [TestMethod]
        public void WhenAddingToTheDBWeGetAllCountries()
        {
            var repo = new NhRepository<Country>(session);
            AddToDatabaseNH db = new AddToDatabaseNH(repo, new CsvCountrieFileParser() );
            db.Add(@"Countries.csv");

            var list = repo.GetAll();
            Assert.AreEqual(245, list.Count);
        }

       
    }
}

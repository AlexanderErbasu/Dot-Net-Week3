using Countries.Ef;
using Countries.Ef.RepositoriesImpl;
using Countries.Entities;
using Countries.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Tests.Ef
{
    [TestClass]
    public class AddToDatabaseTest
    {
        protected string connectionString = @"Data Source=(local);Initial Catalog=Countries;User ID=sa;Password=1234%asd;";

        protected ErpContext session;

        [TestInitialize]
        public void Initialize()
        {
            /* Create a session and execute a query: */
            session = new ErpContext(connectionString);

            session.Database.ExecuteSqlCommand(GetCleanupSql());
        }

        private string GetCleanupSql()
        {
            return "delete from Country";
        }

        [TestCleanup]
        public void Cleanup()
        {
            session.Dispose();
        }

        [TestMethod]
        public void WhenAddingToTheDBWeGetAllCountries()
        {
            var repo = new EfRepository<Country>(session);
            AddToDatabase db = new AddToDatabase(repo, new CsvCountrieFileParser() );
            db.Add(@"Countries.csv");

            var list = repo.GetAll();
            Assert.AreEqual(245, list.Count);
        }

       
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.RepositoriesImpl;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class CategorieRepositoryTests
    {
        private string connectionString = @"Data Source=intern2017-18\test;Initial Catalog=MagazinOnline;User ID=sa;Password=1234%asd;";

        private ICategorieRepository CreateTarget()
        {
            return new CategorieRepository(connectionString);
        }

        #region test assert and cleanup methods
        private void AssertCategorieSame(Categorie expected, Categorie actual, bool testId = false)
        {
            if(testId)
                Assert.AreEqual(expected.CategorieId, actual.CategorieId);
            Assert.AreEqual(expected.Nume, actual.Nume);
        }

        [TestInitialize]
        public void Cleanup()
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(var command = new SqlCommand(@"delete Categorie where Nume = 'Mimescu'", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        [TestMethod]
        public void WhenInsertingOneWeCanGetThatObject()
        {
            var expected = new Categorie
            {
                Nume = "Mimescu"
            };

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id > 0);

            var countFinal = target.GetAll().Count;

            var actual = target.GetById(id);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            AssertCategorieSame(expected, actual);
        }

        [TestMethod]
        public void WhenUpdatingOneWeCanGetThatObject()
        {
            var expected = new Categorie
            {
                Nume = "Mimescu"
            };

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id > 0);

            var actual = target.GetById(id);
            Assert.IsNotNull(actual);

            var countFinal = target.GetAll().Count;

            actual.Nume = "Mirela";

            target.Update(actual);

            actual = target.GetById(id);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            Assert.AreEqual("Mirela", actual.Nume);
        }

        [TestMethod]
        public void WhenDeleteingOneWeCanGetThatObject()
        {
            var expected = new Categorie
            {
                Nume = "Mimescu"
            };

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id > 0);

            var actual = target.GetById(id);
            Assert.IsNotNull(actual);

            target.Delete(id);

            actual = target.GetById(id);
            Assert.IsNull(actual);
        }
    }
}

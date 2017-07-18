using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.RepositoriesImpl;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class ClientRepositoryTests
    {
        private string connectionString = @"Data Source=intern2017-18\test;Initial Catalog=MagazinOnline;User ID=sa;Password=1234%asd;";

        private IClientRepository CreateTarget()
        {
            return new ClientRepository(connectionString);
        }

        #region test assert and cleanup methods
        private void AssertClientSame(Client expected, Client actual, bool testId = false)
        {
            if(testId)
                Assert.AreEqual(expected.ClientId, actual.ClientId);
            Assert.AreEqual(expected.CNP, actual.CNP);
            Assert.AreEqual(expected.Nume, actual.Nume);
            Assert.AreEqual(expected.Prenume, actual.Prenume);
        }

        [TestInitialize]
        public void Cleanup()
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(var command = new SqlCommand(@"delete Client where Nume = 'Mimescu'", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        [TestMethod]
        public void WhenInsertingOneWeCanGetThatObject()
        {
            var expected = new Client
            {
                CNP = "1111181009922",
                Nume = "Mimescu",
                Prenume = "Georgica"
            };

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id > 0);

            var countFinal = target.GetAll().Count;

            var actual = target.GetById(id);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            AssertClientSame(expected, actual);
        }

        [TestMethod]
        public void WhenUpdatingOneWeCanGetThatObject()
        {
            var expected = new Client
            {
                CNP = "1111181009922",
                Nume = "Mimescu",
                Prenume = "Georgica"
            };

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id > 0);

            var actual = target.GetById(id);
            Assert.IsNotNull(actual);

            var countFinal = target.GetAll().Count;

            actual.Prenume = "Mirela";

            target.Update(actual);

            actual = target.GetById(id);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            Assert.AreEqual("Mirela", actual.Prenume);
        }

        [TestMethod]
        public void WhenDeleteingOneWeCanGetThatObject()
        {
            var expected = new Client
            {
                CNP = "1111181009922",
                Nume = "Mimescu",
                Prenume = "Georgica"
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

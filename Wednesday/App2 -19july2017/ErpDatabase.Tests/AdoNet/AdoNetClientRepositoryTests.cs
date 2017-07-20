using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.AdoNet.RepositoriesImpl;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class AdoNetClientRepositoryTests : AdoNetAbstractTest<Client>
    {
        protected override IRepository<Client> CreateTarget()
        {
            return new AdoNetClientRepository(connection);
        }

        protected override void AssertSame(Client expected, Client actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CNP, actual.CNP);
            Assert.AreEqual(expected.Nume, actual.Nume);
            Assert.AreEqual(expected.Prenume, actual.Prenume);
        }

        protected override string GetCleanupSql()
        {
            return "delete Client where Nume = 'Mimescu'";
        }

        protected override Client CreateObject()
        {
            return new Client
            {
                CNP = "1111181009922",
                Nume = "Mimescu",
                Prenume = "Georgica"
            };
        }

        protected override void UpdateObject(Client entity)
        {
            entity.Prenume = "Irina";
        }
    }
}

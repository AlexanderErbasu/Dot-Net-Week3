using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.AdoNet.RepositoriesImpl;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class AdoNetProdusRepositoryTests : AdoNetAbstractTest<Produs>
    {
        protected override IRepository<Produs> CreateTarget()
        {
            return new AdoNetProdusRepository(connection);
        }

        protected override void AssertSame(Produs expected, Produs actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CategorieId, actual.CategorieId);
            Assert.AreEqual(expected.Nume, actual.Nume);
            Assert.AreEqual(expected.Pret, actual.Pret);
        }

        protected override string GetCleanupSql()
        {
            return "delete Produs where Nume = 'Mimescu'";
        }

        protected override Produs CreateObject()
        {
            return new Produs
            {
                CategorieId = 1,
                Nume = "Mimescu",
                Pret = 50
            };
        }

        protected override void UpdateObject(Produs entity)
        {
            entity.Pret = 17;
        }
    }
}

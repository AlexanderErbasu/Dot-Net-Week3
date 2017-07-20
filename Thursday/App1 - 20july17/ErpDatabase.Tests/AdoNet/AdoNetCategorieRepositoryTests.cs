using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.AdoNet.RepositoriesImpl;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class AdoNetCategorieRepositoryTests : AdoNetAbstractTest<Categorie>
    {
        protected override IRepository<Categorie> CreateTarget()
        {
            return new AdoNetCategorieRepository(connection);
        }

        protected override void AssertSame(Categorie expected, Categorie actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Nume, actual.Nume);
        }

        protected override string GetCleanupSql()
        {
            return "delete Categorie where Nume like 'Mimescu%'";
        }

        protected override Categorie CreateObject()
        {
            return new Categorie
            {
                Nume = "Mimescu"
            };
        }

        protected override void UpdateObject(Categorie entity)
        {
            entity.Nume = "Mimescu 2";
        }
    }
}

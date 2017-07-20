using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;
using System.Collections.Generic;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class NhProdusRepositoryTests : NhAbstractTest<Produs>
    {
        protected override void AssertSame(Produs expected, Produs actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Produs CreateObject()
        {
            return new Produs
            {
                Categorie = new Categorie { Id = 1 },
                Nume = "Electrocasnice",
                Pret = 700
            };
        }

        protected override IRepository<Produs> CreateTarget()
        {
            return new NhRepository<Produs>(session);
        }

        protected override string GetCleanupSql()
        {
            return "select 1";// delete LinieComanda where ProdusId = 1";
        }

        protected override void UpdateObject(Produs entity)
        {
            entity.Pret = 50000;
        }
    }
}

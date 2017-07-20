using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Ef.RepositoriesImpl;
using System.Collections.Generic;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class EfProdusRepositoryTests : EfAbstractTest<Produs>
    {
        protected override void AssertSame(Produs expected, Produs actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Produs CreateObject()
        {
            return new Produs
            {
                CategorieId = 1 ,
                Nume = "Electrocasnice",
                Pret = 700
            };
        }

        protected override IRepository<Produs> CreateTarget()
        {
            return new EfRepository<Produs>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete from Produs where Nume = 'Electrocasnice'";
        }

        protected override void UpdateObject(Produs entity)
        {
            entity.Pret = 50000;
        }
    }
}

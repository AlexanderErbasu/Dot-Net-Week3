using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;

namespace ErpDatabase.Tests.Nh
{
    [TestClass]
    public class NhCategorieRepositoryTests : NhAbstractTest<Categorie>
    {
        protected override void AssertSame(Categorie expected, Categorie actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Categorie CreateObject()
        {
            return new Categorie
            {
                
                Nume = "Televizor Samsung",
                
            };
        }

        protected override IRepository<Categorie> CreateTarget()
        {
            return new NhRepository<Categorie>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete Client where Nume = 'Televizor Samsung'";
        }

        protected override void UpdateObject(Categorie entity)
        {
            entity.Nume = "Televizor Philips";
        }
    }
}


using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;

namespace ErpDatabase.Tests.Nh
{
    [TestClass]
    public class NhLinieComandaRepositoryTests : NhAbstractTest<LinieComanda>
    {
        protected override void AssertSame(LinieComanda expected, LinieComanda actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override LinieComanda CreateObject()
        {
            return new LinieComanda
            {

                Comanda = new Comanda { Id = 1 },
                Produs = new Produs { Id = 1 },
                Cantitate = 200
                
            };
        }

        protected override IRepository<LinieComanda> CreateTarget()
        {
            return new NhRepository<LinieComanda>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete LinieComanda where Cantitate = 200";
        }

        protected override void UpdateObject(LinieComanda entity)
        {
            entity.Cantitate = 5000;
        }
    }
}


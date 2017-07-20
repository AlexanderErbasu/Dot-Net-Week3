using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;

namespace ErpDatabase.Tests
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
                Cantitate = 12,
                Comanda = new Comanda { Id = 1 },
                Produs = new Produs { Id = 1 }
            };
        }

        protected override IRepository<LinieComanda> CreateTarget()
        {
            return new NhRepository<LinieComanda>(session);
        }

        protected override string GetCleanupSql()
        {
            return "select 1";// delete LinieComanda where ProdusId = 1";
        }

        protected override void UpdateObject(LinieComanda entity)
        {
            entity.Cantitate = 500;
        }
    }
}

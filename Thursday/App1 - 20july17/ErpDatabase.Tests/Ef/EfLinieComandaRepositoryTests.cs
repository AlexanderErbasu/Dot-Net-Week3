using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Ef.RepositoriesImpl;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class EfLinieComandaRepositoryTests : EfAbstractTest<LinieComanda>
    {
        protected override void AssertSame(LinieComanda expected, LinieComanda actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override LinieComanda CreateObject()
        {
            var comanda = new EfRepository<Comanda>(session).GetById(1);
            var produs = new EfRepository<Produs>(session).GetById(1);

            return new LinieComanda
            {
                Cantitate = 12,
                Comanda = comanda ,
                Produs = produs 
            };
        }

        protected override IRepository<LinieComanda> CreateTarget()
        {
            return new EfRepository<LinieComanda>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete from LinieComanda where ProdusID =1 AND ComandaId=1 And Cantitate = 12";// delete LinieComanda where ProdusId = 1";
        }

        protected override void UpdateObject(LinieComanda entity)
        {
            entity.Cantitate = 500;
        }
    }
}

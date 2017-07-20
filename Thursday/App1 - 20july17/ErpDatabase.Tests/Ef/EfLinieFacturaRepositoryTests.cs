using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Ef.RepositoriesImpl;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class EfLinieFacturaRepositoryTests : EfAbstractTest<LinieFactura>
    {
        protected override void AssertSame(LinieFactura expected, LinieFactura actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override LinieFactura CreateObject()
        {

            var factura = new EfRepository<Factura>(session).GetById(1);
            var linieComanda = new EfRepository<LinieComanda>(session).GetById(1);
            var produs = new EfRepository<Produs>(session).GetById(1);


            return new LinieFactura
            {
                Cantitate = 12,
                Pret = 500,
                Factura = factura,
                LinieComanda = linieComanda,
                Produs = produs
            };
        }

        protected override IRepository<LinieFactura> CreateTarget()
        {
            return new EfRepository<LinieFactura>(session);
        }

        protected override string GetCleanupSql()
        {
            return "select 1";
        }

        protected override void UpdateObject(LinieFactura entity)
        {
            entity.Cantitate = 500;
        }
    }
}

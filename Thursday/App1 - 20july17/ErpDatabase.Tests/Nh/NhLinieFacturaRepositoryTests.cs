using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class NhLinieFacturaRepositoryTests : NhAbstractTest<LinieFactura>
    {
        protected override void AssertSame(LinieFactura expected, LinieFactura actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override LinieFactura CreateObject()
        {
            return new LinieFactura
            {
                Cantitate = 12,
                Pret = 500,
                Factura = new Factura {  Id = 1 },
                LinieComanda = new LinieComanda { Id = 47 },
                Produs = new Produs { Id = 1 }
            };
        }

        protected override IRepository<LinieFactura> CreateTarget()
        {
            return new NhRepository<LinieFactura>(session);
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

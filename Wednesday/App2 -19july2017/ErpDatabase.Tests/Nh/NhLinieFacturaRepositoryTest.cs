using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;
using System.Collections.Generic;

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
            var LinieFactura = new LinieFactura
            {
                Factura = new Factura { Id = 1 },
                LinieComanda = new LinieComanda { Id =1},
                Pret = 4545,
                Produs = new Produs { Id = 1 },
                Cantitate = 34
            };
            

            return LinieFactura;
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
            entity.Pret = 7890;

        }
                
    }
}

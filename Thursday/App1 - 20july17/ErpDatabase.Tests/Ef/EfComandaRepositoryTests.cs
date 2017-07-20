using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Ef.RepositoriesImpl;
using System.Collections.Generic;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class EfComandaRepositoryTests : EfAbstractTest<Comanda>
    {
        protected override void AssertSame(Comanda expected, Comanda actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Comanda CreateObject()
        {
            var client = new EfRepository<Client>(session).GetById(1);
            var produs = new EfRepository<Produs>(session).GetById(1);

            var comanda = new Comanda
            {
                Finalizata = false,
                Client = client,
                Linii = new List<LinieComanda>()
            };

            comanda.Linii.Add(new LinieComanda { Cantitate = 999, Comanda = comanda,
                Produs = produs
            });

            comanda.Linii.Add(new LinieComanda { Cantitate = 1000, Comanda = comanda,
                Produs = produs
            });

            return comanda;
        }

        protected override IRepository<Comanda> CreateTarget()
        {
            return new EfRepository<Comanda>(session);
        }

        protected override string GetCleanupSql()
        {
            return "select 1";// delete LinieComanda where ProdusId = 1";
        }

        protected override void UpdateObject(Comanda entity)
        {
            entity.Finalizata = true;
        }

        [TestMethod]
        public void WhenInsertingComandaWith2LiniiWeGet2Linii()
        {
            var expected = CreateObject();

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id > 0);

            var countFinal = target.GetAll().Count;

            var actual = target.GetById(id);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            AssertSame(expected, actual);

            Assert.AreEqual(expected.Linii.Count, actual.Linii.Count);

            for(int i = 0; i < expected.Linii.Count; i++)
            {
                var expectedLinie = expected.Linii[i];
                var actualLinie = actual.Linii[i];

                expected.AssertAreSame(actual, true);
            }
        }

    }
}

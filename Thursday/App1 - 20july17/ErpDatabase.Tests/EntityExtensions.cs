using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpDatabase.Tests
{
    public static class EntityExtensions
    {
        public static void AssertAreSame(this Client expected, Client actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CNP.Trim(), actual.CNP.Trim());
            Assert.AreEqual(expected.Nume, actual.Nume);
            Assert.AreEqual(expected.Prenume, actual.Prenume);
        }

        public static void AssertAreSame(this Produs expected, Produs actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CategorieId, actual.CategorieId);
            Assert.AreEqual(expected.Nume, actual.Nume);
            Assert.AreEqual(expected.Pret, actual.Pret);
        }

        public static void AssertAreSame(this Categorie expected, Categorie actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Nume, actual.Nume);
        }

        public static void AssertAreSame(this Comanda expected, Comanda actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Finalizata, actual.Finalizata);
            Assert.AreEqual(expected.Client.Id, actual.Client.Id);
        }

        public static void AssertAreSame(this LinieComanda expected, LinieComanda actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Cantitate, actual.Cantitate);
            Assert.AreEqual(expected.Comanda.Id, actual.Comanda.Id);
            Assert.AreEqual(expected.Produs.Id, actual.Produs.Id);
        }

        public static void AssertAreSame(this LinieFactura expected, LinieFactura actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Cantitate, actual.Cantitate);
            Assert.AreEqual(expected.Pret, actual.Pret);

            if (null != expected.LinieComanda && null != actual.LinieComanda)
                Assert.AreEqual(expected.LinieComanda.Id, actual.LinieComanda.Id);

            if (null != expected.Produs && null != actual.Produs)
                Assert.AreEqual(expected.Produs.Id, actual.Produs.Id);

            if (null != expected.Factura && null != actual.Factura)
                Assert.AreEqual(expected.Factura.Id, actual.Factura.Id);
        }

        public static void AssertAreSame(this Factura expected, Factura actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Comanda.Id, actual.Comanda.Id);
            Assert.AreEqual(expected.Client.Id, actual.Client.Id);
        }
    }
}

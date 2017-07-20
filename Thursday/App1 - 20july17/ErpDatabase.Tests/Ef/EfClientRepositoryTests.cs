using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Ef.RepositoriesImpl;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class EfClientRepositoryTests : EfAbstractTest<Client>
    {
        protected override void AssertSame(Client expected, Client actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Client CreateObject()
        {
            return new Client
            {
                CNP = "1111181009922",
                Nume = "Mimescu",
                Prenume = "Georgica"
            };
        }

        protected override IRepository<Client> CreateTarget()
        {
            return new EfRepository<Client>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete from Client where CNP = '1111181009922'";
        }

        protected override void UpdateObject(Client entity)
        {
            entity.Prenume = "Irina";
        }
    }
}

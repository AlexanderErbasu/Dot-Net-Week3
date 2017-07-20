using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;
using ErpDatabase.Ef.RepositoriesImpl;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class EfClientRepositoryTests : EfAbstractTest<Client>
    {
        protected override IRepository<Client> CreateTarget()
        {
            return new EfRepository<Client>(session);
        }
    }
}

using Countries.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Countries.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Ef.RepositoriesImpl;

namespace Countries.Tests.Ef
{
    class EfCountriesRepositoryTest
    {
        [TestClass]
        public class EfCountriesRepositoryTests : EfAbstractTest<Country>
        {
            protected override void AssertSame(Country expected, Country actual, bool testId = false)
            {
                expected.AssertAreSame(actual, testId);
            }

            protected override Country CreateObject()
            {
                return new Country
                {
                    //SI,46.151241,14.995463,Slovenia
                    Code = "SI",
                    Latitude = (decimal?)46.151241,
                    Longitude = (decimal?)14.995463,
                    Nume = "Slovenia"
                };
            }

            protected override IRepository<Country> CreateTarget()
            {
                return new EfRepository<Country>(session);
            }

            protected override string GetCleanupSql()
            {
                return "delete from Country where Cod = 'SI'";
            }

            protected override void UpdateObject(Country entity)
            {
                entity.Nume = "Slovakia";
            }
        }

    }
}

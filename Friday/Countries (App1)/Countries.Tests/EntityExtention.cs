using Countries.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Tests
{
    public static class EntityExtensions
    {
        public static void AssertAreSame(this Country expected, Country actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Code, actual.Code);
            Assert.AreEqual(expected.Latitude, actual.Latitude);
            Assert.AreEqual(expected.Longitude, actual.Longitude);
            Assert.AreEqual(expected.Nume, actual.Nume);
        }
    }
}

using Countries.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Countries.Tests
{
    public abstract class AbstractTest<T>
               where T : IEntity, new()
    {
        protected string connectionString = @"Data Source=(local);Initial Catalog=Countries;User ID=sa;Password=1234%asd;";

        protected abstract IRepository<T> CreateTarget();

        protected abstract void AssertSame(T expected, T actual, bool testId = false);

        protected abstract string GetCleanupSql();

        protected abstract T CreateObject();

        protected abstract void UpdateObject(T entity);

        [TestMethod]
        public void WhenInsertingOneWeCanGetThatObject()
        {
            var expected = CreateObject();

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id != null);

            var countFinal = target.GetAll().Count;

            var actual = target.GetById(id);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            AssertSame(expected, actual);
        }

        [TestMethod]
        public void WhenUpdatingOneWeCanGetThatObject()
        {
            var expected = CreateObject();

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id != null);

            expected = target.GetById(id);
            Assert.IsNotNull(expected);

            var countFinal = target.GetAll().Count;

            UpdateObject(expected);

            target.Update(expected);

            var actual = target.GetById(id);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            AssertSame(expected, actual, true);
        }

        [TestMethod]
        public void WhenDeleteingOneWeCanGetThatObject()
        {
            var expected = CreateObject();

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id != null);

            var actual = target.GetById(id);
            Assert.IsNotNull(actual);

            target.Delete(id);

            actual = target.GetById(id);
            Assert.IsNull(actual);
        }
    }
}

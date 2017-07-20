using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Tests
{
    public abstract class AdoNetAbstractTest<T> : AbstractTest<T>
        where T : IEntity, new()
    {
        protected SqlConnection connection;

        [TestInitialize]
        public void Initialize()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            using (var command = new SqlCommand(GetCleanupSql(), connection))
            {
                command.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            connection.Dispose();
        }
    }
}

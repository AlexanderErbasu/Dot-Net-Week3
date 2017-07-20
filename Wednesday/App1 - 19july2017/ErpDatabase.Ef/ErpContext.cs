using ErpDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Ef
{
    public class ErpContext : DbContext
    {
        public ErpContext(string connectionString):base(connectionString)
        {

        }
        public DbSet<Client> Clients { get; set; }
    }
}

using Countries.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Ef
{
    public class ErpContext : DbContext
    {
        public ErpContext(string connectionString) : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ErpContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Country>()
                .Property(a => a.Latitude)
                .HasPrecision(20, 8);

            modelBuilder.Entity<Country>()
            .Property(a => a.Longitude)
            .HasPrecision(20, 8);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Country> Country { get; set; }
    }
}

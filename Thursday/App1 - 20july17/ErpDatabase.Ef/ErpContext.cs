using ErpDatabase.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ErpDatabase.Ef
{
    public class ErpContext : DbContext
    {
        public ErpContext(string connectionString):base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ErpContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //suntem pe romana, pluralizarea face ciudat Produs -> Produses

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Categorie> Categorie { get; set; } //Asemanatoare cu mapare
        public DbSet<Produs> Produs { get; set; }
        public DbSet<LinieComanda> LinieComanda { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<LinieFactura> LinieFactura { get; set; }
    }
}

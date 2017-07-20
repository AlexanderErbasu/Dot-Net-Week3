using ErpDatabase.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Nh.Mappings
{
    public class LinieFacturaMap : ClassMapping<LinieFactura>
    {
        public LinieFacturaMap()
        {
            this.Table("LinieFactura");
            Id(p => p.Id, a =>
            {
                a.Column("LinieFacturaId");
                a.Generator(Generators.Identity);
            });
            ManyToOne(p => p.Factura, m =>
            {
                m.Column("FacturaId");
            });
            ManyToOne(p => p.LinieComanda, m =>
            {
                m.Column("LinieComandaId");
            });
            ManyToOne(p => p.Produs, m =>
            {
                m.Column("ProdusId");
            });
            this.Property(p => p.Cantitate);
            this.Property(p => p.Pret);
        }
    }
}

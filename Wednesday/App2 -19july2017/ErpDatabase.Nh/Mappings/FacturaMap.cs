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
    public class FacturaMap : ClassMapping<Factura>
    {
        public FacturaMap()
        {
            this.Table("Factura");
            Id(p => p.Id, a =>
            {
                a.Column("FacturaId");
                a.Generator(Generators.Identity);
            });
            ManyToOne(p => p.Client, m =>
            {
                m.Column("ClientId");
                m.Lazy(LazyRelation.NoLazy);
                m.Fetch(FetchKind.Join);
            });
            ManyToOne(p => p.Comanda, m =>
            {
                m.Column("ComandaID");
                m.Lazy(LazyRelation.NoLazy);
                m.Fetch(FetchKind.Join);
            });
            
            Bag(p => p.Linii, cm =>
            {
                cm.Fetch(CollectionFetchMode.Subselect);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Table("LinieFacutura");
                cm.Inverse(true);
                cm.Key(k => k.Column("FacturaId"));
            },
            action => action.OneToMany());
            
        }
    }
}

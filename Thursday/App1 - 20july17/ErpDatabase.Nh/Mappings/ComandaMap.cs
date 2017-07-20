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
    public class ComandaMap : ClassMapping<Comanda>
    {
        public ComandaMap()
        {
            this.Table("Comanda");
            Id(p => p.Id, a =>
            {
                a.Column("ComandaId");
                a.Generator(Generators.Identity);
            });
            ManyToOne(p => p.Client, m =>
            {
                m.Column("ClientId");
            });
            this.Property(p => p.Finalizata);
            Bag(p => p.Linii, cm =>
            {   
                cm.Fetch(CollectionFetchMode.Subselect);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Inverse(true);
                cm.Table("LinieComanda");
                cm.Key(k => k.Column("ComandaId"));
            }, 
            action => action.OneToMany());
        }
    }
}

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
    public class ProdusMap : ClassMapping<Produs>
    {
        public ProdusMap()
        {
            this.Table("Produs");
            Id(p => p.Id, a =>
            {
                a.Column("ProdusId");
                a.Generator(Generators.Identity);
            });
            ManyToOne(p => p.Categorie, m =>
            {
                m.Column("CategorieId");
                m.Lazy(LazyRelation.NoLazy);
                m.Fetch(FetchKind.Join);
            });
            this.Property(p => p.Nume);
            this.Property(p => p.Pret);
        }
    }
}

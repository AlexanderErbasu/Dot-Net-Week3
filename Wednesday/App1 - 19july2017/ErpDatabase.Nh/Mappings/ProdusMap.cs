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
            this.Property(p => p.Nume);

            ManyToOne(p => p.Categorie, m =>
            {
                m.Column("CategorieId");
            });


            this.Property(p => p.Pret);
        }
    }
}

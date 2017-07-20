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
    public class CategorieMap : ClassMapping<Categorie>
    {
        public CategorieMap()
        {
            this.Table("Categorie");
            Id(p => p.Id, a =>
            {
                a.Column("CategorieId");
                a.Generator(Generators.Identity);
            });
            this.Property(p => p.Nume);
        }
    }
}

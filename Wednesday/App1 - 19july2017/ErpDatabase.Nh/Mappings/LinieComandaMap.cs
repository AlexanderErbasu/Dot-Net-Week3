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
    public class LinieComandaMap : ClassMapping<LinieComanda> //TREBUIE SA FIE PUBLIC!!!!!
    {
        public LinieComandaMap()
        {
            this.Table("LinieComanda");
            Id(p => p.Id, a =>
            {
                a.Column("LinieComandaId"); //daca are alt nume!!!
                a.Generator(Generators.Identity);
            });

            ManyToOne(p => p.Comanda, m =>
            {
                m.Column("ComandaId");
            });

            ManyToOne(p => p.Produs, m =>
            {
                m.Column("ProdusId");
            });

            this.Property(p => p.Cantitate);

        }
    }
}

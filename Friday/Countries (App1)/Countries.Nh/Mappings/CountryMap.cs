using NHibernate.Mapping.ByCode.Conformist;
using Countries.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Nh.Mappings
{
    public class CountryMap : ClassMapping<Country>
    {
        public CountryMap()
        {
            this.Table("Country");
            Id(p => p.Code, a =>
           {
               a.Column("Cod");
           });
            this.Property(p => p.Latitude, a => {
                a.Column("Latitudine");
                a.Precision(20);
                a.Scale(8);
                });

            this.Property(p => p.Longitude, a => {
                a.Column("Longitudine");
                a.Precision(20);
                a.Scale(8);
            });
            this.Property(p => p.Nume);
        }
    }
}

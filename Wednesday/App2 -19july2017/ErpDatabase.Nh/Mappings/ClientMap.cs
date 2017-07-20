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
    public class ClientMap : ClassMapping<Client>
    {
        public ClientMap()
        {
            this.Table("Client");
            Id(p => p.Id, a =>
            {
                a.Column("ClientId");
                a.Generator(Generators.Identity);
            });
            this.Property(p => p.CNP);
            this.Property(p => p.Nume);
            this.Property(p => p.Prenume);
        }
    }
}

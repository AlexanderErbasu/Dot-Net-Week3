using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class LinieFactura : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual LinieComanda LinieComanda { get; set; }
        public virtual decimal Pret { get; set; }
        public virtual Produs Produs { get; set; }
        public virtual int Cantitate { get; set; }
    }
}

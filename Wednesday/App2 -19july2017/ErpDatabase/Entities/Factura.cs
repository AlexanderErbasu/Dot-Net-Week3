using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Factura : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual Comanda Comanda { get; set; }
        public virtual IList<LinieFactura> Linii { get; set; }
    }
}

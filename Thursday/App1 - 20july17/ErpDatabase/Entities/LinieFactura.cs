using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class LinieFactura : IEntity
    {
        [Column("LinieFacturaId")]
        public virtual int Id { get; set; }

        public virtual int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public virtual Factura Factura { get; set; }

        public virtual int LinieComandaId { get; set; }
        [ForeignKey("LinieComandaId")]
        public virtual LinieComanda LinieComanda { get; set; }
        
        public virtual int ProdusId { get; set; }
        [ForeignKey("ProdusId")]
        public virtual Produs Produs { get; set; }

        public virtual decimal Pret { get; set; }

        public virtual int Cantitate { get; set; }
    }
}

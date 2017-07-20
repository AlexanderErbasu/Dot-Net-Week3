using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class LinieComanda : IEntity
    {
        [Column("LinieComandaId")]
        public virtual int Id { get; set; }

        public virtual int ComandaId { get; set; }
        [ForeignKey("ComandaId")]
        public virtual Comanda Comanda { get; set; }

        public virtual int ProdusId { get; set; }
        [ForeignKey("ProdusId")]
        public virtual Produs Produs { get; set; }
        public virtual int Cantitate { get; set; }
    }
}

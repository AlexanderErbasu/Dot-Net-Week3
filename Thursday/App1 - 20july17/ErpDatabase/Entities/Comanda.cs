using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Comanda : IEntity
    {
        [Column("ComandaId")]
        public virtual int Id { get; set; }


        public virtual int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public virtual bool Finalizata { get; set; }

        [InverseProperty("Comanda")]//cand el se duce in entitatea de liniecomanda, sa caute entitatea de linie comanda, si sa le lege intre ele? 
        public virtual IList<LinieComanda> Linii { get; set; }
    }
}

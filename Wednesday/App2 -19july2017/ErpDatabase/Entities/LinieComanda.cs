using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class LinieComanda : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Comanda Comanda { get; set; }
        public virtual Produs Produs { get; set; }
        public virtual int Cantitate { get; set; }
    }
}

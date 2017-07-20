using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Comanda : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual bool Finalizata { get; set; }
        public virtual IList<LinieComanda> Linii { get; set; }
    }
}

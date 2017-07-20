using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Produs : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Nume { get; set; }

        public virtual int CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual decimal Pret { get; set; }
    }
}

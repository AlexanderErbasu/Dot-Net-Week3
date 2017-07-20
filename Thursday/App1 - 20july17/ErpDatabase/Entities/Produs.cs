using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Produs : IEntity
    {
        [Column("ProdusId")]
        public virtual int Id { get; set; }

        public virtual string Nume { get; set; }

        public virtual int CategorieId { get; set; }

        [ForeignKey("CategorieId")] //trebuie sa foloseasca foreign key-ul care este pus pe coloana CategorieId
        public virtual Categorie Categorie { get; set; }

        public virtual decimal Pret { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Categorie : IEntity
    {
        public int Id { get; set; }
        public string Nume { get; set; }
    }
}

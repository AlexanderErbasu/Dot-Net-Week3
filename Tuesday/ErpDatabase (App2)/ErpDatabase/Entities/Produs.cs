
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Produs : IEntity
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int CategorieID { get; set; }
        public decimal Pret { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    [Table("Client")]
    public class Client : IEntity
    {
        [Key]
        [Column("ClientId")]
        public virtual int Id { get; set; }

        public virtual string Nume { get; set; }

        public virtual string Prenume { get; set; }

        public virtual string CNP { get; set; }
    }
}

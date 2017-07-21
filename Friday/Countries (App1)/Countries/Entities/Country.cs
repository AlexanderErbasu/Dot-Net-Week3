using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Countries.Entities
{
    public class Country : IEntity
    {
        [Key]
        [Column("Cod")]
        public virtual string Code { get; set; }
        [Column ("Latitudine")]
        public virtual decimal? Latitude { get; set; }
        [Column("Longitudine")]
        public virtual decimal? Longitude { get; set; }
        public virtual string Nume { get; set; }
    }
}

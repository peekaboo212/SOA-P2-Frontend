using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        [StringLength(18)]
        public string curp { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        [StringLength(50)]
        [Required]
        public string last_name { get; set; }
        [DataType(DataType.Date)]
        public DateTime birth_date { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}

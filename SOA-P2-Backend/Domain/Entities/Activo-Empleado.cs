using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Activo_Empleado")]
    public class Activo_Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [ForeignKey("Empleado")]
        public int id_empleoyee { get; set; }
        [Required]
        [ForeignKey("Activo")]
        public int id_activo { get; set; }
        public DateTime assignment_date { get; set; }
        public DateTime release_date { get; set; }
        public DateTime delivery_date { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Activo Activo { get; set; }
    }
}

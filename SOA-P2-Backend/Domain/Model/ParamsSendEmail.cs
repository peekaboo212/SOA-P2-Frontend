using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ParamsSendEmail
    {
        [Required]
        public int id_empleoyee { get; set; } = 0;
        [Required]
        public int id_activo { get; set; } = 0;
        [Required]
        public string deliveryDate { get; set; } = string.Empty;
    }
}

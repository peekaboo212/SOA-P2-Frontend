using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class RequestPostAssignActivo
    {
        [Required]
        public int id_empleoyee { get; set; } = 0;
        [Required]
        public int id_activo { get; set; } = 0;
        [Required]
        public string delivery_date { get; set; } = string.Empty;
    }
}

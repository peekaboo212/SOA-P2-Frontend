using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class RequestPostCreateEmployee
    {
        [Required, MaxLength(18)]
        public string curp { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string name { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string last_name { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string birth_date { get; set; } = string.Empty;
        [Required, MaxLength(255)]
        public string email { get; set; } = string.Empty;
    }
}

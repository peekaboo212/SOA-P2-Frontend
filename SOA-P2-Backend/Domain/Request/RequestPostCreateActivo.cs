using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class RequestPostCreateActivo
    {
        [Required, MaxLength(100)]
        public string name { get; set; } = string.Empty;
        [Required, MaxLength(255)]
        public string description { get; set; } = string.Empty;
    }
}

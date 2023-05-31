using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class RequestPatchUpdateStatusActivo
    {
        [Required]
        public int id { get; set; } = 0;
        [Required]
        public bool status { get; set; } = false;
    }
}

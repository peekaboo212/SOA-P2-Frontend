using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpleadoVM
    {
        public string curp { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public int num_employee { get; set; }
        public string email { get; set; }
        public DateTime date_hire { get; set; }
        public bool status { get; set; }
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ParamsNotificationDelivery
    {
        public int id { get; set; }
        public int id_empleoyee { get; set; }
        public int id_activo { get; set; }
        public DateTime assignment_date { get; set; }
        public DateTime release_date { get; set; }
        public DateTime delivery_date { get; set; }
    }
}

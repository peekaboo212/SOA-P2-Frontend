using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DataActivoEmployeeNotificationEmail
    {
        public string nameEmployee { get; set; }
        public string lastnameEmployee { get; set; }
        public string email { get; set; }
        public string nameActivo { get; set; }
        public string description { get; set; }
        public DateTime assignmentDate { get; set; }
        public DateTime releseDate { get; set; }

        public int id { get; set; }
        public int id_empleoyee { get; set; }
        public int id_activo { get; set; }
        public DateTime assignment_date { get; set; }
        public DateTime release_date { get; set; }
        public DateTime delivery_date { get; set; }
    }
}

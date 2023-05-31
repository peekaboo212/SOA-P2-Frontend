using Domain.Entities;
using Domain.Model;
using Domain.Request;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class Activo_EmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public Activo_EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AssignActivo (RequestPostAssignActivo assignActivo)
        {
            Activo activo = _context.Activos.FirstOrDefault(a => a.id == assignActivo.id_activo && !a.status);
            if (activo != null)
            {
                _context.Activo_Empleado.Add(new Activo_Empleado
                {
                    id_activo = assignActivo.id_activo,
                    id_empleoyee = assignActivo.id_empleoyee,
                    assignment_date = DateTime.Now,
                    release_date = DateTime.Parse(assignActivo.delivery_date)
                });
                activo.status = true;
                _context.SaveChanges();
            } else
            {
                throw new Exception("Error provocado");
            }
        }

        public void deliveryActivo (RequestPatchDeliveryActivo deliveryActivo)
        {
            Activo_Empleado activo_Empleado = _context.Activo_Empleado.FirstOrDefault(
                a => a.id_activo == deliveryActivo.id_activo && a.id_empleoyee == deliveryActivo.id_empleoyee && a.delivery_date == DateTime.MinValue);

            if (activo_Empleado != null)
            {
                activo_Empleado.delivery_date = DateTime.Now;
                Activo activo = _context.Activos.FirstOrDefault(a => a.id == deliveryActivo.id_activo);
                if (activo != null)
                {
                    activo.status = false;
                }
                _context.SaveChanges();
            } else
            {
                throw new Exception("Error provocado");
            }
        }

        public List<DataActivoEmployeeNotificationEmail> GetAllUndelivered()
        {
            List<DataActivoEmployeeNotificationEmail> list = new List<DataActivoEmployeeNotificationEmail> ();

            list = _context.Activo_Empleado
                .Include(x => x.Empleado)
                    .ThenInclude(e => e.Persona)
                .Include(x => x.Activo).Where(x => x.delivery_date == DateTime.MinValue)
                .Select(x => new DataActivoEmployeeNotificationEmail
            {
                nameEmployee = x.Empleado.Persona.name,
                lastnameEmployee = x.Empleado.Persona.last_name,
                email = x.Empleado.email,
                nameActivo = x.Activo.name,
                description = x.Activo.description,
                assignmentDate = x.assignment_date,
                releseDate = x.release_date,
                assignment_date = x.assignment_date,
                delivery_date = x.delivery_date,
                id = x.id,
                id_activo = x.id_activo,
                id_empleoyee = x.id_empleoyee,
                release_date = x.release_date,
            }).ToList();

            return list;
        }
    }
}

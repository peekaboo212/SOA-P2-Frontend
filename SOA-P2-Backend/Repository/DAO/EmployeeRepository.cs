using Domain.Entities;
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
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Empleado> GetList()
        {
            List<Empleado> list = new List<Empleado>();

            list = _context.Empleados.Include(x => x.Persona).ToList();

            return list;
        }

        public void AddEmployee(RequestPostCreateEmployee newEmployee)
        {
            Console.WriteLine(newEmployee.name);
            _context.Personas.Add(new Persona
            {
                curp = newEmployee.curp,
                name = newEmployee.name,
                last_name = newEmployee.last_name,
                birth_date = DateTime.Parse(newEmployee.birth_date),
            });

            _context.Empleados.Add(new Empleado
            {
                id_people = newEmployee.curp,
                email = newEmployee.email,
                date_hire = DateTime.Now,
                status = true
            });

            _context.SaveChanges();
        }
    }
}

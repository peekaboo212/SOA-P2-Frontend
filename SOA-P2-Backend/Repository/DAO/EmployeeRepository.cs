using Domain.Entities;
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
    }
}

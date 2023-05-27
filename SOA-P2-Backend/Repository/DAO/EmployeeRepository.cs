using Domain.Entities;
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

        public List<Persona> GetList()
        {
            List<Persona> list = new List<Persona>();

            list = _context.Personas.ToList();

            return list;
        }
    }
}

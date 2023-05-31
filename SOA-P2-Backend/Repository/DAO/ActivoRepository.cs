using Domain.Entities;
using Domain.Request;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class ActivoRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddActivo (RequestPostCreateActivo newActivo)
        {
            _context.Activos.Add(new Activo
            {
                name = newActivo.name,
                description = newActivo.description,
                status = false
            });

            _context.SaveChanges();
        }

        public Activo GetById(int id)
        {
            Activo activo = new Activo();

            activo = _context.Activos.FirstOrDefault(x => x.id == id);

            return activo;
        }

        public void UpdateStatusActivo(RequestPatchUpdateStatusActivo newStatus)
        {
            Activo activo = _context.Activos.FirstOrDefault(a => a.id == newStatus.id);

            if (activo != null)
            {
                activo.status = newStatus.status;
                _context.SaveChanges();
            }
        }

        public List<Activo> GetAll()
        {
            List<Activo> activos = new List<Activo>();

            activos = _context.Activos.ToList();

            return activos;
        }
    }
}

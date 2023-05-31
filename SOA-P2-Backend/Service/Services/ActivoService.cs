using Domain.Entities;
using Domain.Request;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ActivoService : IActivo
    {
        private readonly ILogger<ActivoService> _logger;
        private readonly ActivoRepository activoRepository;

        public ActivoService(ILogger<ActivoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            activoRepository = new ActivoRepository(context);
        }

        public List<Activo> GetAll()
        {
            List<Activo> activos = new List<Activo>();

            try
            {
                activos = activoRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return activos;
        }

        public string AddActivo(RequestPostCreateActivo newActivo)
        {
            try
            {
                activoRepository.AddActivo(newActivo);
                return "Activo creado";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "No se pudo, crear el activo";
        }

        public string UpdateStatusActivo(RequestPatchUpdateStatusActivo newStatus)
        {
            try
            {
                activoRepository.UpdateStatusActivo(newStatus);
                return "Status del activo actualizado";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "No se pudo, actualizar el status del activo";
        }
    }
}

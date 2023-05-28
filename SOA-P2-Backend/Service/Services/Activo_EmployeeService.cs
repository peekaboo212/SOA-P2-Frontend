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
    public class Activo_EmployeeService : IActivo_Employee
    {
        private readonly ILogger<Activo_EmployeeService> _logger;
        private readonly Activo_EmployeeRepository activo_EmployeeRepository;

        public Activo_EmployeeService(ILogger<Activo_EmployeeService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            activo_EmployeeRepository = new Activo_EmployeeRepository(context);
        }

        public string AssignActivo(RequestPostAssignActivo assignActivo)
        {
            try
            {
                activo_EmployeeRepository.AssignActivo(assignActivo);
                return "Activo asignado";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "No se pudo, asignar el activo";
        }

        public string DeliveryActivo(RequestPatchDeliveryActivo deliveryActivo)
        {
            try
            {
                activo_EmployeeRepository.deliveryActivo(deliveryActivo);
                return "Activo entregado";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "No se pudo, entregar el activo";
        }
    }
}

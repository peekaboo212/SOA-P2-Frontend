using Domain.Entities;
using Domain.Model;
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
        private readonly IEmail _email;

        public Activo_EmployeeService(ILogger<Activo_EmployeeService> logger, ApplicationDbContext context, IEmail email)
        {
            _logger = logger;
            activo_EmployeeRepository = new Activo_EmployeeRepository(context);
            _email = email;
        }

        public string AssignActivo(RequestPostAssignActivo assignActivo)
        {
            try
            {
                activo_EmployeeRepository.AssignActivo(assignActivo);
                _email.SendAssignmentActivo(new ParamsSendEmail
                {
                    id_activo = assignActivo.id_activo,
                    id_empleoyee = assignActivo.id_empleoyee,
                    deliveryDate = assignActivo.delivery_date
                });
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
                _email.SendDeliveryActivo(new ParamsSendEmail
                {
                    id_activo = deliveryActivo.id_activo,
                    id_empleoyee = deliveryActivo.id_empleoyee,
                    deliveryDate = DateTime.Now.ToString("yyyy-MM-dd")
                });
                return "Activo entregado";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "No se pudo, entregar el activo";
        }

        public List<DataActivoEmployeeNotificationEmail> GetAllUndelivered()
        {
            List<DataActivoEmployeeNotificationEmail> list = new List<DataActivoEmployeeNotificationEmail>();

            try
            {
                list = activo_EmployeeRepository.GetAllUndelivered();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return list;
        }

        public List<DataActivoEmployeeNotificationEmail> GetAllUndeliveredSendNotification()
        {
            List<DataActivoEmployeeNotificationEmail> list = new List<DataActivoEmployeeNotificationEmail>();

            try
            {
                list = activo_EmployeeRepository.GetAllUndelivered();
                for (int i = 0; i < list.Count; i++)
                {
                    _email.SentNotificationDelivery(list[i]);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return list;
        }
    }
}

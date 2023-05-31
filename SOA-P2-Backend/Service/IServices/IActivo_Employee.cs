using Domain.Entities;
using Domain.Model;
using Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IActivo_Employee
    {
        string AssignActivo(RequestPostAssignActivo assignActivo);

        string DeliveryActivo(RequestPatchDeliveryActivo deliveryActivo);
        List<DataActivoEmployeeNotificationEmail> GetAllUndelivered();
        List<DataActivoEmployeeNotificationEmail> GetAllUndeliveredSendNotification();
    }
}

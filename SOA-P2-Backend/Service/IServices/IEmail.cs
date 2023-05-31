using Domain.Entities;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IEmail
    {
        string SendAssignmentActivo(ParamsSendEmail paramsSendEmail);
        string SendDeliveryActivo(ParamsSendEmail paramsSendEmail);
        void SentNotificationDelivery(DataActivoEmployeeNotificationEmail data);
    }
}

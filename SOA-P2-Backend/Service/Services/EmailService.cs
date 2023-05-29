﻿using Azure;
using Domain.Entities;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmailService : IEmail
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _configuration;
        private readonly EmployeeRepository empleoyeeRepository;
        private readonly ActivoRepository activoRepository;
        private SmtpClient _smtpClient;
        private string _emailOrigin;

        public EmailService(ILogger<EmailService> logger, IConfiguration configuration, ApplicationDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            empleoyeeRepository = new EmployeeRepository(context);
            activoRepository = new ActivoRepository(context);
            _emailOrigin = _configuration.GetSection("EmailCredentials:email").Value;
            _smtpClient = ConfigureSmtpClient();
        }

        public string SendAssignmentActivo(ParamsSendEmail paramsSendEmail)
        {
            Activo activo = new Activo();
            EmpleadoVM empleadoVM = new EmpleadoVM();

            try
            {
                activo = activoRepository.GetById(paramsSendEmail.id_activo);
                empleadoVM = empleoyeeRepository.GetEmpleadoById(paramsSendEmail.id_empleoyee);

                if (activo != null && empleadoVM != null) 
                {
                    MailMessage mailMessage = new MailMessage(_emailOrigin, empleadoVM.email);
                    mailMessage.Subject = $"Asignación del activo: {activo.name}";
                    mailMessage.Body = $"<b>Hola, {empleadoVM.name}</b><br>Se le fue asignado el activo: <b>{activo.name}</b><br>Fecha entrega: {paramsSendEmail.deliveryDate}";
                    mailMessage.IsBodyHtml = true;
                    _smtpClient.Send(mailMessage);
                    _smtpClient.Dispose();
                    return "Correo enviado";
                }
                else
                {
                    return "No se puedo enviar el correo";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return "No se puedo enviar el correo";
            }
        }

        public string SendDeliveryActivo(ParamsSendEmail paramsSendEmail)
        {
            Activo activo = new Activo();
            EmpleadoVM empleadoVM = new EmpleadoVM();

            try
            {
                activo = activoRepository.GetById(paramsSendEmail.id_activo);
                empleadoVM = empleoyeeRepository.GetEmpleadoById(paramsSendEmail.id_empleoyee);

                if (activo != null && empleadoVM != null)
                {
                    MailMessage mailMessage = new MailMessage(_emailOrigin, empleadoVM.email);
                    mailMessage.Subject = $"Entrega del activo: {activo.name}";
                    mailMessage.Body = $"<b>Hola, {empleadoVM.name}</b><br>Realizaste la entrega del activo: <b>{activo.name}</b><br>Fecha entrega: {paramsSendEmail.deliveryDate}";
                    mailMessage.IsBodyHtml = true;
                    _smtpClient.Send(mailMessage);
                    _smtpClient.Dispose();
                    return "Correo enviado";
                }
                else
                {
                    return "No se puedo enviar el correo";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return "No se puedo enviar el correo";
            }
        }

        public void SentNotificationDelivery(int id_activo, int id_employee, DateTime delivery)
        {
            DateTime releaseDate = delivery;
            DateTime twoDaysLater = DateTime.Now.AddDays(1);

            if (releaseDate.Date == twoDaysLater.Date)
            {
                Console.WriteLine(id_activo);
                Console.WriteLine(id_employee);
                Console.WriteLine(delivery);
            }

            /*MailMessage mailMessage = new MailMessage(_emailOrigin, "alexandergv2117@gmail.com");
            mailMessage.Subject = $"Entrega del activo";
            mailMessage.Body = $"<b>Hola,</b><br>Realizaste la entrega del activo: <b></b><br>Fecha entrega: {delivery}";
            mailMessage.IsBodyHtml = true;
            _smtpClient.Send(mailMessage);
            _smtpClient.Dispose();*/
        }

        private SmtpClient ConfigureSmtpClient()
        {
            string password = _configuration.GetSection("EmailCredentials:password").Value;
            int port = int.Parse(_configuration.GetSection("EmailCredentials:port").Value);
            bool enableSsl = bool.Parse(_configuration.GetSection("EmailCredentials:EnableSsl").Value);
            string smtpClientHost = _configuration.GetSection("EmailCredentials:smtpClient").Value;
            bool useDefaultCredentials = bool.Parse(_configuration.GetSection("EmailCredentials:UseDefaultCredentials").Value);

            SmtpClient smtpClient = new SmtpClient(smtpClientHost);
            smtpClient.EnableSsl = enableSsl;
            smtpClient.UseDefaultCredentials = useDefaultCredentials;
            smtpClient.Port = port;
            smtpClient.Credentials = new System.Net.NetworkCredential(_emailOrigin, password);

            return smtpClient;
        }
    }
}

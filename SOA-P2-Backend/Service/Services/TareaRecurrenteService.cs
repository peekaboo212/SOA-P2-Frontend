using Microsoft.Extensions.Hosting;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TareaRecurrenteService : IHostedService, IDisposable, ITareaRecurrente
    {
        private Timer _timer;
        private readonly IActivo_Employee _activo_Employee;
        public TareaRecurrenteService(IActivo_Employee activo_Employee)
        {
            _activo_Employee = activo_Employee;
        }
        public Task StartAsync (CancellationToken cancellationToken)
        {
            _timer = new Timer(Notification, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
        public void Notification(object state)
        {
            Console.WriteLine("test");
        }
    }
}

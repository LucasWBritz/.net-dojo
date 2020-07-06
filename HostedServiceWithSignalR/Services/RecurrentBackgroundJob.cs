using HostedServiceSample.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace HostedServiceSample.Services
{
    public class RecurrentBackgroundJob : BackgroundService
    {
        private readonly ILogger<RecurrentBackgroundJob> _logger;
        private readonly IHubContext<JobHub> _hub;

        private static int Counter = 0;

        public RecurrentBackgroundJob(ILogger<RecurrentBackgroundJob> logger, IHubContext<JobHub> hub)
        {
            _logger = logger;
            _hub = hub;

            _logger.LogInformation("Starting service now.");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hub.Clients.All.SendAsync("SetCounter", Counter);
                Counter++;

                await Task.Delay(5000);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping Service now.");
            return base.StopAsync(cancellationToken);
        }
    }
}

using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class BackgroundService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await NotificationSystem.KeepCheckingRequests();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

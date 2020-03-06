using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dotnet_mediatr.Infrastructure.BackgroundServices.Scheduler
{
    public class DailyGreetings : IHostedService
    {
        private readonly ILogger<DailyGreetings> _logger;

        public DailyGreetings(ILogger<DailyGreetings> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("start background task daily greetings");
            Timer timer = new Timer(Greetings, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop background task daily greetings");
            return Task.CompletedTask;
        }

        public void Greetings(object state)
        {
            var content = new List<string>()
            {
                DateTime.Now.ToString(),
                "Hello"
            };


            _logger.LogInformation($"greeting from {content.Last()}");
            System.IO.File.AppendAllLinesAsync("Greetings.txt", content);
        }
    }
}

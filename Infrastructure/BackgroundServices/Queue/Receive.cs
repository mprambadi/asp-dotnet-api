using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace dotnet_mediatr.Infrastructure.BackgroundServices.Queue
{
    public class ReceiverQueue : IHostedService
    {
        private readonly ILogger<ReceiverQueue> _logger;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public ReceiverQueue(ILogger<ReceiverQueue> logger)
        {
            _logger = logger;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop background task queue");
            return Task.CompletedTask;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("start background task queue");
            Consumer(_channel);
            return Task.CompletedTask;
        }

        public void Consumer(IModel channel)
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($" [x] Received {message}");

            };
            channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
        }
    }
}

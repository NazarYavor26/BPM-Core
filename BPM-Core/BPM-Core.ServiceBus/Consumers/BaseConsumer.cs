using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BPM_Core.ServiceBus.Consumers
{
    public abstract class BaseConsumer : BackgroundService
    {
        protected string _hostname;
        protected string _queueName;
        private IConnection _connection;
        private IModel _channel;

        protected BaseConsumer()
        { }

        protected void Initialize(string hostname, string queueName)
        {
            _hostname = hostname;
            _queueName = queueName;

            var factory = new ConnectionFactory() { HostName = _hostname };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName,
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += OnMessageReceived;

            _channel.BasicConsume(queue: _queueName,
                                  autoAck: true,
                                  consumer: consumer);

            return Task.CompletedTask;
        }

        protected abstract void OnMessageReceived(object model, BasicDeliverEventArgs ea);
    }
}

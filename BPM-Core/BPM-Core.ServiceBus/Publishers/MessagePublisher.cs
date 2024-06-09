using RabbitMQ.Client;
using System.Text;

namespace BPM_Core.ServiceBus.Publishers
{
    public class MessagePublisher
    {
        public void PublishMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                while (true)
                {
                    Console.WriteLine("Enter a message (or 'exit' to quit):");
                    string message = Console.ReadLine();
                    if (message.ToLower() == "exit")
                    {
                        break;
                    }

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
        }
    }
}

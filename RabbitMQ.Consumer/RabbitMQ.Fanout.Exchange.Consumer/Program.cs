
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new("amqps://qryvqupu:qNwJLRjbEFh9MBNM2BGIyikyyPEcxVXz@chimpanzee.rmq.cloudamqp.com/qryvqupu");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "fanout-example-exchange", type: ExchangeType.Fanout);

Console.Write("Quyruq adini daxil edin:");
string queueName = Console.ReadLine();

channel.QueueDeclare(queue:queueName,exclusive:false);

channel.QueueBind(queue: queueName, exchange: "fanout-example-exchange", routingKey: string.Empty);

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

consumer.Received += (sender, e) =>
{
    string message = Encoding.UTF8.GetString(e.Body.Span);
    Console.WriteLine(message);
};
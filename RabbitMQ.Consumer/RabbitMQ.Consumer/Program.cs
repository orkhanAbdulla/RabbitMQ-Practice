//Bağlantı oluşturma
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory Factory = new();
Factory.Uri = new("amqps://qryvqupu:qNwJLRjbEFh9MBNM2BGIyikyyPEcxVXz@chimpanzee.rmq.cloudamqp.com/qryvqupu");

//Bağlantını aktiv etmək və Kanal açnaq

using IConnection connection = Factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Oluşturma
channel.QueueDeclare(queue: "example-queue", exclusive: false);//Consumer-da da queue publisherde olduqu kimi bire bire eyni qeyd olunmalidi

// Queue-dən messaj Oxuma

EventingBasicConsumer consumer=new(channel);
channel.BasicConsume(queue: "example-queue", false, consumer);
consumer.Received += (sender, e) =>
{
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
};
Console.Read();



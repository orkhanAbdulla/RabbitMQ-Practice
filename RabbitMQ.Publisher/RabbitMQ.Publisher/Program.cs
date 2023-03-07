using RabbitMQ.Client;
using System.Text;



//Bağlantı oluşturma
ConnectionFactory Factory = new();
Factory.Uri = new("amqps://qryvqupu:qNwJLRjbEFh9MBNM2BGIyikyyPEcxVXz@chimpanzee.rmq.cloudamqp.com/qryvqupu");

//Bağlantını aktiv etmək və Kanal açnaq

using IConnection connection = Factory.CreateConnection();
using IModel channel=connection.CreateModel();

//Queue Oluşturma

channel.QueueDeclare(queue: "example-queue",exclusive:false,durable:true);

// Queue-ya Mesaj Gönderme

//RabbitMQ queue-ya atacaqi mesajları byte tipinən qəbul etməkdədir.

IBasicProperties properties=channel.CreateBasicProperties();
properties.Persistent = true;

byte[] message=Encoding.UTF8.GetBytes("Merhaba");
channel.BasicPublish(exchange:"",routingKey:"example-queue",body:message,basicProperties: properties);

Console.Read();



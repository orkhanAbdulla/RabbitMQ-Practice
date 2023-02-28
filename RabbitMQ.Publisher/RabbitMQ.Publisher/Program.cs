using RabbitMQ.Client;
using System.Text;



//Bağlantı oluşturma
ConnectionFactory Factory = new();
Factory.Uri = new("amqps://qryvqupu:qNwJLRjbEFh9MBNM2BGIyikyyPEcxVXz@chimpanzee.rmq.cloudamqp.com/qryvqupu");

//Bağlantını aktiv etmək və Kanal açnaq

using IConnection connection = Factory.CreateConnection();
using IModel channel=connection.CreateModel();

//Queue Oluşturma

channel.QueueDeclare(queue: "example-queue",exclusive:false);

// Queue-ya Mesaj Gönderme

//RabbitMQ queue-ya atacaqi mesajları byte tipinən qəbul etməkdədir.

byte[] message=Encoding.UTF8.GetBytes("Merhaba");
channel.BasicPublish(exchange:"",routingKey:"example-queue",body:message);

Console.Read();



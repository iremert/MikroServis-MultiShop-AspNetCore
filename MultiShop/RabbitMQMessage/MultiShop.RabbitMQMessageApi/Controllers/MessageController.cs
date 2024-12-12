using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName="localhost"
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Kuyruk 2",false,false,false,arguments:null);
            var messageContent = "Merhaba bugün güzel bir gün.";
            var byteMessageContent=Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange: "", routingKey: "Kuyruk 2", basicProperties: null, body: byteMessageContent);


            return Ok("Mesajınız kuyruğa alınmıştır.");
        }



        private static string message;
        [HttpGet]
        public IActionResult ReadMessage()
        {
        
            var factory = new ConnectionFactory();
            factory.HostName="localhost";
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message=Encoding.UTF8.GetString(byteMessage);   
            };
            channel.BasicConsume(queue: "Kuyruk 1", autoAck: false, consumer: consumer);
            

            if(string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            return Ok(message);
        }
    }
}

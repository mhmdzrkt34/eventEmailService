using Events;

using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailConsumerServicce.Consumers
{
    public class SendEmailEventConsumer : IConsumer<SendEmailEvent>
    {

        private readonly ILogger<SendEmailEventConsumer> _logger;

        public SendEmailEventConsumer(ILogger<SendEmailEventConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<SendEmailEvent> context)
        {

            SendEmailEvent message = context.Message;
            Console.WriteLine(message.email);




           
            return Task.CompletedTask;
        }
    }
}

using EasyNetQ.AutoSubscribe;
using MassTransit;
using Sample.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Components
{
    public class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
           await context.RespondAsync<OrderSubmissionAccepted>(new
           {
                InVar.Timestamp,
                context.Message.OrderId
            });
        }
    }
}

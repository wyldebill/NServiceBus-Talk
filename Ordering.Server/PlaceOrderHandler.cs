#region PlaceOrderHandler
namespace Ordering.Server
{
    using System;
    using Messages;
    using NServiceBus;

    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        IBus bus;

        public PlaceOrderHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(PlaceOrder message)
        {
            // extract the info you need from the message, and do your 'work'

            Console.WriteLine(@"Order for Product:{0} processing with id: {1}", message.Product, message.Id);


            #region Exception 
            //throw new Exception("boom");
            #endregion

            #region Publish the OrderCompleted event 
             OrderCompleted order = new OrderCompleted
            {
                OrderId=message.Id,
                OrderTotal = message.OrderTotal,
                CustomerId = message.CustomerId
            };

            bus.Publish(order);
            #endregion
        }
    }
}
#endregion

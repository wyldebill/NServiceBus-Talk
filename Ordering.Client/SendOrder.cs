#region SendOrder
namespace Ordering.Client
{
    using System;
    using Messages;
    using NServiceBus;

    public class OrderClient : IWantToRunWhenBusStartsAndStops
    {
        IBus bus;

        public OrderClient(IBus bus)
        {
            this.bus = bus;
        }

        public void Start()
        {
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            while (Console.ReadLine() != null)
            {
                Guid id = Guid.NewGuid();

                PlaceOrder placeOrder = new PlaceOrder
                {
                    CustomerId=101,
                    OrderTotal = 150,
                    Product = "New shoes", 
                    Id = id
                };

                bus.Send(placeOrder);

                Console.WriteLine("Sent a new PlaceOrder message with id: {0}", id.ToString("N"));
            }
        }

        public void Stop()
        {
        }
    }
}
#endregion
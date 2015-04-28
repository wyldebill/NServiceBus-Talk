#region PlaceOrder
namespace Ordering.Messages
{
    using System;
    using NServiceBus;

    public class PlaceOrder : ICommand
    {
        public Guid Id { get; set; }
        public int OrderTotal { get; set; }
        public string Product { get; set; }
        public int CustomerId { get; set; }
    }
}
#endregion
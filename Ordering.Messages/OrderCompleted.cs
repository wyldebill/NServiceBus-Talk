using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Messages
{
    public class OrderCompleted : IEvent
    {
        public Guid OrderId { get; set;}
        public int CustomerId { get; set; }
        public int OrderTotal { get; set; }
    }
}

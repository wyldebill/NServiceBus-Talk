using NServiceBus.Saga;
using Ordering.Messages;
using System;


namespace Ordering.Server
{
    public class OrderPolicy : Saga<OrderPolicyData>,
        IAmStartedByMessages<OrderCompleted>{
        
        
        public void Handle(OrderCompleted message)
        {
            this.Data.CustomerId = message.CustomerId;
 	        this.Data.OrderTotal += message.OrderTotal;

            Console.WriteLine("Evaluating total orders for customer {0}", message.CustomerId);

            if (this.Data.OrderTotal > 500)
            {
                Console.WriteLine("***********   Preferred Status achievement: UNLOCKED!!!! ******************");

                this.MarkAsComplete();
            }
            else
            {
                Console.WriteLine("Order total is only {0}, keep ordering!!", this.Data.OrderTotal);
            }


        }

    
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderPolicyData> mapper)
        {
 	        mapper.ConfigureMapping<OrderCompleted>(m => m.CustomerId)
				.ToSaga(s => s.CustomerId);
        }
}


    public class OrderPolicyData : ContainSagaData
    {
       
        public Guid OrderId {get;set;}
        public int OrderTotal {get; set;}
        [Unique]
        public int CustomerId {get; set;}

    }
}

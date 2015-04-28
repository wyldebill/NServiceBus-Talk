namespace Ordering.Server
{
    using System;
    using NServiceBus;
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
	    public void Customize(BusConfiguration configuration)
	    {
	        configuration.UsePersistence<InMemoryPersistence>();
            Console.WriteLine("ready to process orders");
	    }
    }
}
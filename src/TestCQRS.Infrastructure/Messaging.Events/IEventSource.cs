namespace TestCQRS.Infrastructure.Messaging.Events
{
	using System.Collections.Generic;

	public interface IEventSource
	{
		IEnumerable<IEvent> GetEvents();
	}
}

namespace TestCQRS.Server.Events
{
	using System.Collections.Generic;

	public interface IEventSource
	{
		IEnumerable<IEvent> FlushEvents();
	}
}

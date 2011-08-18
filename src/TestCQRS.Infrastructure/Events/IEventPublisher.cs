namespace TestCQRS.Infrastructure.Events
{
	using System.Collections.Generic;

	public interface IEventPublisher
	{
		/// <summary>
		/// Publishes event.
		/// </summary>
		/// <param name="event">Event to publish.</param>
		void Publish(IEvent @event);

		/// <summary>
		/// Publishes multiple events.
		/// </summary>
		/// <param name="events">Events to publish.</param>
		void Publish(IEnumerable<IEvent> events);
	}
}

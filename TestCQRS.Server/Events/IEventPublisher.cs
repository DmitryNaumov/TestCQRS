namespace TestCQRS.Server.Events
{
	public interface IEventPublisher
	{
		/// <summary>
		/// Publishes event.
		/// </summary>
		/// <param name="event">Event to publish.</param>
		void Publish(IEvent @event);
	}
}

namespace TestCQRS.Server.Events
{
	public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
	{
		/// <summary>
		/// Handles event.
		/// </summary>
		/// <param name="event">Event to handle.</param>
		void Handle(TEvent @event);
	}
}

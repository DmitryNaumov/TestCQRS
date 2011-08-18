namespace TestCQRS.Infrastructure.Events
{
	using System.Collections.Generic;

	public interface IEventStore
	{
		/// <summary>
		/// Adds event to <see cref="IEventStore"/>.
		/// </summary>
		/// <param name="event">Event to add.</param>
		void Add(IEvent @event);

		/// <summary>
		/// Gets all events stored at <see cref="IEventStore"/> occurred after the moment specified by given sequence number.
		/// </summary>
		/// <param name="seqNumber">Sequence number identifying a history moment.</param>
		/// <returns>Returns all events that occurred later after the moment specified.</returns>
		IEnumerable<IEvent> Get(long? seqNumber);
	}
}

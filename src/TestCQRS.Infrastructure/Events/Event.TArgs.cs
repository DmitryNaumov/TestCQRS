namespace TestCQRS.Infrastructure.Events
{
	public sealed class Event<TArgs> : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Event{TArgs}"/> class.
		/// </summary>
		/// <param name="args">Event arguments.</param>
		public Event(TArgs args)
		{
			Args = args;
		}

		/// <summary>
		/// Gets the data associated with the event.
		/// </summary>
		public TArgs Args { get; private set; }
	}
}

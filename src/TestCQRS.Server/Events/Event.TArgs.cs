namespace TestCQRS.Server.Events
{
	public sealed class Event<TArgs> : Event
	{
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

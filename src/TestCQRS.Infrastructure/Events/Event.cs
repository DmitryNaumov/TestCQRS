namespace TestCQRS.Infrastructure.Events
{
	using System;
	using System.Threading;

	public abstract class Event : IEvent
	{
		private static long _lastSeqNo;

		/// <summary>
		/// Initializes a new instance of the <see cref="Event"/> class.
		/// </summary>
		protected Event()
		{
			SeqNo = Interlocked.Increment(ref _lastSeqNo);
			CreationDate = DateTime.UtcNow;
		}

		/// <summary>
		/// Auto-incremented event number. Used to build event sequence.
		/// </summary>
		public long SeqNo { get; private set; }

		/// <summary>
		/// Gets the time when event was created.
		/// </summary>
		public DateTime CreationDate { get; private set; }

		/// <summary>
		/// Gets the time when event was posted.
		/// </summary>
		public DateTime PostDate { get; private set; }

		/// <summary>
		/// Creates new instance of the <see cref="Event{TArgs}"/> initialized with the given arguments.
		/// </summary>
		/// <typeparam name="TArgs">Type of the event arguments.</typeparam>
		/// <param name="args">Event arguments.</param>
		/// <returns>Returns new event instance.</returns>
		public static Event<TArgs> New<TArgs>(TArgs args)
		{
			return new Event<TArgs>(args);
		}
	}
}

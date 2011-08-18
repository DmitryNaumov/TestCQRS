namespace TestCQRS.Server.Events
{
	using System;
	using System.Threading;

	public abstract class Event : IEvent
	{
		private static long _lastSeqNo;

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

		public static Event<TArgs> New<TArgs>(TArgs args)
		{
			return new Event<TArgs>(args);
		}
	}
}

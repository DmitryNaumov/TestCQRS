namespace TestCQRS.Server.Events
{
	using System;

	public interface IEvent
	{
		/// <summary>
		/// Auto-incremented event number. Used to build event sequence.
		/// </summary>
		long SeqNo { get; }

		/// <summary>
		/// Gets the time when event was created.
		/// </summary>
		DateTime CreationDate { get; }

		/// <summary>
		/// Gets the time when event was posted.
		/// </summary>
		DateTime PostDate { get; }
	}
}

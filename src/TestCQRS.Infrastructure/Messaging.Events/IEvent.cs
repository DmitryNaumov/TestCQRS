namespace TestCQRS.Infrastructure.Messaging.Events
{
	using System;

	public interface IEvent : IMessage
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

namespace TestCQRS.Infrastructure.Messaging.Commands
{
	using System;

	public interface ICommand : IMessage
	{
		/// <summary>
		/// Gets the globally unique command identifier used to track events caused by the command.
		/// </summary>
		Guid Id { get; }
	}
}

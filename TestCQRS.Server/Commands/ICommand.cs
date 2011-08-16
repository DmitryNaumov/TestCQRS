namespace TestCQRS.Server.Commands
{
	using System;

	public interface ICommand
	{
		/// <summary>
		/// Gets the globally unique command identifier used to track events caused by the command.
		/// </summary>
		Guid Id { get; }
	}
}

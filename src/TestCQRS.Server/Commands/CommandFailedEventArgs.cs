namespace TestCQRS.Server.Commands
{
	using System;

	public sealed class CommandFailedEventArgs : CommandEventArgs
	{
		public CommandFailedEventArgs(ICommand command, Exception failure)
			: base(command)
		{
			Exception = failure;
		}

		/// <summary>
		/// Gets the failure exception.
		/// </summary>
		public Exception Exception { get; private set; }
	}
}

namespace TestCQRS.Server.Commands
{
	using System;

	public sealed class CommandFailedEventArgs : CommandEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandFailedEventArgs"/> class.
		/// </summary>
		/// <param name="command">Original command.</param>
		/// <param name="exception">Failure exception.</param>
		public CommandFailedEventArgs(ICommand command, Exception exception)
			: base(command)
		{
			Exception = exception;
		}

		/// <summary>
		/// Gets the failure exception.
		/// </summary>
		public Exception Exception { get; private set; }
	}
}

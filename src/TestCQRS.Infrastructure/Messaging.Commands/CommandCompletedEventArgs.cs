namespace TestCQRS.Infrastructure.Messaging.Commands
{
	public sealed class CommandCompletedEventArgs : CommandEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandCompletedEventArgs"/> class.
		/// </summary>
		/// <param name="command">Original command.</param>
		public CommandCompletedEventArgs(ICommand command)
			: base(command)
		{
		}
	}
}

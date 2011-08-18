namespace TestCQRS.Server.Commands
{
	public sealed class CommandCompletedEventArgs : CommandEventArgs
	{
		public CommandCompletedEventArgs(ICommand command)
			: base(command)
		{
		}
	}
}

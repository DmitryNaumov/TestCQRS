namespace TestCQRS.Server.Commands
{
	public abstract class CommandEventArgs
	{
		protected CommandEventArgs(ICommand command)
		{
			Command = command;
		}

		/// <summary>
		/// Gets the original command.
		/// </summary>
		public ICommand Command { get; private set; }
	}
}

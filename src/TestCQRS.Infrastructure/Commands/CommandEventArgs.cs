namespace TestCQRS.Infrastructure.Commands
{
	public abstract class CommandEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandEventArgs"/> class.
		/// </summary>
		/// <param name="command">Original command.</param>
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

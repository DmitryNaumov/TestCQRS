namespace TestCQRS.Server.Commands
{
	public sealed class CommandPostedEventArgs : CommandEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandPostedEventArgs"/> class.
		/// </summary>
		/// <param name="command">Original command.</param>
		public CommandPostedEventArgs(ICommand command)
			: base(command)
		{
		}
	}
}

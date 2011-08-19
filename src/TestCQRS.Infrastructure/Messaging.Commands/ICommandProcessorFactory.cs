namespace TestCQRS.Infrastructure.Messaging.Commands
{
	public interface ICommandProcessorFactory
	{
		/// <summary>
		/// Creates processor for the specified <see cref="ICommand"/>.
		/// </summary>
		/// <param name="command">Command to process.</param>
		/// <returns>Returns command processor instance.</returns>
		ICommandProcessor Create(ICommand command);
	}
}

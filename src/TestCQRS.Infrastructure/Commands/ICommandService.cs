namespace TestCQRS.Infrastructure.Commands
{
	public interface ICommandService
	{
		/// <summary>
		/// Executes command.
		/// </summary>
		/// <param name="command">Command to execute.</param>
		void ExecuteCommand(ICommand command);
	}
}

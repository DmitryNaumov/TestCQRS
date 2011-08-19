namespace TestCQRS.Infrastructure.Messaging.Commands
{
	using TestCQRS.Infrastructure.DomainModel;

	public interface ICommandProcessor
	{
		/// <summary>
		/// Performs pre-validation of command against the current model state.
		/// </summary>
		void PreValidate(IDomainModelState model);

		/// <summary>
		/// Executes command to change model state.
		/// </summary>
		void Execute(IDomainModelState model);

		/// <summary>
		/// Performs post-validation of model state changed by the command.
		/// </summary>
		void PostValidate(IDomainModelState model);
	}
}

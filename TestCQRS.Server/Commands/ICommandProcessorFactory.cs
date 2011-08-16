﻿namespace TestCQRS.Server.Commands
{
	public interface ICommandProcessorFactory
	{
		/// <summary>
		/// Creates processor for the specified <see cref="ICommand"/>.
		/// </summary>
		/// <param name="unitOfWork">Unit of work for the command.</param>
		/// <param name="command">Command to process.</param>
		/// <returns>Returns command processor instance.</returns>
		ICommandProcessor Create(IUnitOfWork unitOfWork, ICommand command);
	}
}
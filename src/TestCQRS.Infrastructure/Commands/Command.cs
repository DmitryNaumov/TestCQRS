namespace TestCQRS.Infrastructure.Messaging.Commands
{
	using System;

	public abstract class Command : ICommand
	{
		protected Command()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; private set; }
	}
}

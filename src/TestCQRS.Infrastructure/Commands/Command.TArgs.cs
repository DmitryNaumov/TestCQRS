namespace TestCQRS.Infrastructure.Messaging.Commands
{
	public sealed class Command<TArgs> : Command
	{
		public Command(TArgs args)
		{
			Args = args;
		}

		public TArgs Args { get; private set; }
	}
}

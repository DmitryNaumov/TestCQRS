namespace TestCQRS.Server.Impl
{
	using TestCQRS.Infrastructure.Messaging;
	using TestCQRS.Infrastructure.Messaging.Commands;

	internal sealed class BookOrderCommandHandler : IMessageHandler<Command<BookOrderCommandArgs>>
	{
		public void Handle(Command<BookOrderCommandArgs> command)
		{
			// TODO:
		}
	}
}

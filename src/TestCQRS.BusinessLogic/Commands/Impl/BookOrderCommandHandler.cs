namespace TestCQRS.BusinessLogic.Commands.Impl
{
	using TestCQRS.BusinessLogic.DomainModel;
	using TestCQRS.Infrastructure.DomainModel;
	using TestCQRS.Infrastructure.Messaging;
	using TestCQRS.Infrastructure.Messaging.Commands;

	internal sealed class BookOrderCommandHandler : IMessageHandler<Command<BookOrderCommandArgs>>
	{
		private readonly IRepository _repository;

		public BookOrderCommandHandler(IRepository repository)
		{
			_repository = repository;
		}

		public void Handle(Command<BookOrderCommandArgs> command)
		{
			var order = _repository.Get<Order>(command.Args.OrderId);
			order.Book();
		}
	}
}

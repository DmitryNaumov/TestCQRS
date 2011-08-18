namespace TestCQRS.Server.DomainModel.Impl
{
	using TestCQRS.Server.Events;

	internal sealed class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly IEventPublisher _eventPublisher;

		public UnitOfWorkFactory(IEventPublisher eventPublisher)
		{
			_eventPublisher = eventPublisher;
		}

		public IUnitOfWork Create(IDomainModelState model)
		{
			// TODO: use container-aware factory
			return new UnitOfWork(_eventPublisher, model);
		}
	}
}

namespace TestCQRS.Infrastructure.DomainModel.Impl
{
	using TestCQRS.Infrastructure.Events;

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

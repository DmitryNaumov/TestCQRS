namespace TestCQRS.Infrastructure.DomainModel.Impl
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TestCQRS.Infrastructure.Messaging.Events;

	internal sealed class UnitOfWork : IUnitOfWork
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IDomainModelState _model;

		public UnitOfWork(IEventPublisher eventPublisher, IDomainModelState model)
		{
			_eventPublisher = eventPublisher;
			_model = model;
		}

		public void Commit()
		{
			var events = GetEventSources(_model)
				.SelectMany(eventSource => eventSource.GetEvents())
				.OrderBy(@event => @event.SeqNo)
				.ToArray();

			_eventPublisher.Publish(events);
		}

		public void Dispose()
		{
			// TODO:
		}

		private static IEnumerable<IEventSource> GetEventSources(IDomainModelState model)
		{
			// TODO:
			throw new NotImplementedException();
		}
	}
}

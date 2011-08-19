namespace TestCQRS.Infrastructure.DomainModel
{
	using TestCQRS.Infrastructure.Messaging.Events;

	public interface IAggregateRoot : IEntity, IEventSource
	{
		/// <summary>
		/// Gets the unique identifier.
		/// </summary>
		long Id { get; }
	}
}

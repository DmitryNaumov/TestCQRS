namespace TestCQRS.Server.DomainModel
{
	using TestCQRS.Server.Events;

	public interface IAggregateRoot : IEntity, IEventSource
	{
		/// <summary>
		/// Gets the unique identifier.
		/// </summary>
		long Id { get; }
	}
}

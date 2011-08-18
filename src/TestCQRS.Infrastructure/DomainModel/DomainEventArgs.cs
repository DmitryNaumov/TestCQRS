namespace TestCQRS.Infrastructure.DomainModel
{
	public abstract class DomainEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DomainEventArgs"/> class.
		/// </summary>
		/// <param name="aggregateRoot">Source of event.</param>
		protected DomainEventArgs(IAggregateRoot aggregateRoot)
		{
			AggregateRoot = aggregateRoot;
		}

		/// <summary>
		/// Gets the <see cref="IAggregateRoot"/> that is source of event.
		/// </summary>
		public IAggregateRoot AggregateRoot { get; private set; }
	}
}

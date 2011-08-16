namespace TestCQRS.Server.DomainModel
{
	public abstract class DomainEventArgs
	{
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

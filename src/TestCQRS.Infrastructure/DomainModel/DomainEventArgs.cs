namespace TestCQRS.Infrastructure.DomainModel
{
	public abstract class DomainEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DomainEventArgs"/> class.
		/// </summary>
		/// <param name="root">Source of event.</param>
		protected DomainEventArgs(IAggregateRoot root)
		{
			Root = root;
		}

		/// <summary>
		/// Gets the <see cref="IAggregateRoot"/> that is source of event.
		/// </summary>
		public IAggregateRoot Root { get; private set; }
	}
}

namespace TestCQRS.Server.DomainModel
{
	public interface IAggregateRoot
	{
		/// <summary>
		/// Gets the unique identifier.
		/// </summary>
		long Id { get; }
	}
}

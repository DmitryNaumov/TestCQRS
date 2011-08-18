namespace TestCQRS.Infrastructure.DomainModel
{
	public interface IRepository
	{
		/// <summary>
		/// Gets the specified <see cref="IAggregateRoot"/> instance.
		/// </summary>
		/// <typeparam name="TRoot">Object type.</typeparam>
		/// <param name="objectId">Object identifier.</param>
		/// <returns>Returns the instance specified by the given identifier.</returns>
		TRoot Get<TRoot>(long objectId) where TRoot : IAggregateRoot;
	}
}

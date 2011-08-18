namespace TestCQRS.Server.DomainModel
{
	public interface IRepository
	{
		/// <summary>
		/// Gets the specified <see cref="IAggregateRoot"/> instance.
		/// </summary>
		/// <typeparam name="TAggregateRoot">Object type.</typeparam>
		/// <param name="objectId">Object identifier.</param>
		/// <returns>Returns the instance specified by the given identifier.</returns>
		TAggregateRoot Get<TAggregateRoot>(long objectId) where TAggregateRoot : IAggregateRoot;
	}
}

namespace TestCQRS.Infrastructure.DomainModel
{
	public interface IDomainModelState : IRepository
	{
		/// <summary>
		/// Gets the model state version.
		/// </summary>
		long Version { get; }
	}
}

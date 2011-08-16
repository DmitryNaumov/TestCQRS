namespace TestCQRS.Server.DomainModel
{
	public interface IDomainModelState
	{
		/// <summary>
		/// Gets the model state version.
		/// </summary>
		long Version { get; }
	}
}
